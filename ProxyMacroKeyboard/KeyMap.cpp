#include "KeyMap.h"

String upper(const String& s) {
  String r = s;
  for (int i = 0; i < r.length(); i++) r[i] = (char)toupper(r[i]);
  return r;
}

uint8_t keyFromName(const String& keyName) {
  String k = upper(keyName);
  k.trim();

  if (k.length() == 1) return (uint8_t)k[0];

  if (k == "ENTER") return KEY_RETURN;
  if (k == "TAB") return KEY_TAB;
  if (k == "ESC") return KEY_ESC;
  if (k == "BACKSPACE") return KEY_BACKSPACE;
  if (k == "SPACE") return (uint8_t)' ';

  if (k == "UP") return KEY_UP_ARROW;
  if (k == "DOWN") return KEY_DOWN_ARROW;
  if (k == "LEFT") return KEY_LEFT_ARROW;
  if (k == "RIGHT") return KEY_RIGHT_ARROW;

  if (k == "CTRL") return KEY_LEFT_CTRL;
  if (k == "SHIFT") return KEY_LEFT_SHIFT;
  if (k == "ALT") return KEY_LEFT_ALT;
  if (k == "GUI" || k == "WIN") return KEY_LEFT_GUI;

  if (k.startsWith("F")) {
    int n = k.substring(1).toInt();
    switch (n) {
      case 1: return KEY_F1;
      case 2: return KEY_F2;
      case 3: return KEY_F3;
      case 4: return KEY_F4;
      case 5: return KEY_F5;
      case 6: return KEY_F6;
      case 7: return KEY_F7;
      case 8: return KEY_F8;
      case 9: return KEY_F9;
      case 10: return KEY_F10;
      case 11: return KEY_F11;
      case 12: return KEY_F12;
    }
  }

  return 0;
}
