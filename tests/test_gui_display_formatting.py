import unittest

from ui.main_window import _format_device_id, _format_device_ids_in_text


class GuiDisplayFormattingTests(unittest.TestCase):
    def test_device_id_is_always_at_least_five_digits(self):
        self.assertEqual(_format_device_id(3), "00003")
        self.assertEqual(_format_device_id(1004), "01004")
        self.assertEqual(_format_device_id(65535), "65535")

    def test_missing_device_id_uses_requested_placeholder(self):
        self.assertEqual(_format_device_id(None), "—")
        self.assertEqual(_format_device_id(None, missing="None"), "None")

    def test_operator_log_device_ids_are_normalized(self):
        self.assertEqual(
            _format_device_ids_in_text("Found DeviceId=3; DeviceID: 1004"),
            "Found DeviceId=00003; DeviceID: 01004",
        )


if __name__ == "__main__":
    unittest.main()
