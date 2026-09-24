from __future__ import annotations

import unittest
from types import SimpleNamespace

from ui.main_window import (
    DeviceSettingMainWindow,
    _ROLE_KIND,
    _ROLE_NAME,
)


class _FakeItem:
    def __init__(self, text: str, *, kind: str | None = None, name: str = "") -> None:
        self._text = text
        self._children: list[_FakeItem] = []
        self._data = {
            (0, _ROLE_KIND): kind,
            (0, _ROLE_NAME): name,
        }
        self.hidden = False
        self.expanded = False

    def add_child(self, child: _FakeItem) -> None:
        self._children.append(child)

    def data(self, column, role):
        return self._data.get((column, role))

    def text(self, _column: int) -> str:
        return self._text

    def childCount(self) -> int:
        return len(self._children)

    def child(self, index: int) -> _FakeItem:
        return self._children[index]

    def setHidden(self, hidden: bool) -> None:
        self.hidden = hidden

    def setExpanded(self, expanded: bool) -> None:
        self.expanded = expanded


class _FakeTree:
    def __init__(self, *items: _FakeItem) -> None:
        self._items = list(items)

    def topLevelItemCount(self) -> int:
        return len(self._items)

    def topLevelItem(self, index: int) -> _FakeItem:
        return self._items[index]


class SettingsParameterFilterTests(unittest.TestCase):
    def setUp(self) -> None:
        self.category = _FakeItem("General")
        self.branch = _FakeItem("Safety")
        self.watchdog = _FakeItem(
            "WatchdogTimeMs",
            kind="setting",
            name="Safety.WatchdogTimeMs",
        )
        self.retry = _FakeItem(
            "RetryCount",
            kind="setting",
            name="Communication.RetryCount",
        )
        self.branch.add_child(self.watchdog)
        self.branch.add_child(self.retry)
        self.category.add_child(self.branch)
        self.window = SimpleNamespace(settings_tree_widget=_FakeTree(self.category))

    def apply_filter(self, text: str) -> None:
        DeviceSettingMainWindow._filter_settings_tree(self.window, text)

    def test_filter_matches_complete_parameter_name_case_insensitively(self) -> None:
        self.apply_filter("watchDOG")

        self.assertFalse(self.watchdog.hidden)
        self.assertTrue(self.retry.hidden)
        self.assertFalse(self.branch.hidden)
        self.assertFalse(self.category.hidden)
        self.assertTrue(self.branch.expanded)
        self.assertTrue(self.category.expanded)

    def test_filter_hides_empty_parent_branches(self) -> None:
        self.apply_filter("not-present")

        self.assertTrue(self.watchdog.hidden)
        self.assertTrue(self.retry.hidden)
        self.assertTrue(self.branch.hidden)
        self.assertTrue(self.category.hidden)

    def test_empty_filter_restores_every_parameter(self) -> None:
        self.apply_filter("retry")
        self.apply_filter("")

        self.assertFalse(self.watchdog.hidden)
        self.assertFalse(self.retry.hidden)
        self.assertFalse(self.branch.hidden)
        self.assertFalse(self.category.hidden)


if __name__ == "__main__":
    unittest.main()
