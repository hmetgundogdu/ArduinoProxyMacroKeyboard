#include "Commands.h"
#include <Keyboard.h>
#include "KeyMap.h"

void doPRESS(const String& args) {
  int last = 0;
  for (int i = 0; i <= args.length(); i++) {
    if (i == args.length() || args[i] == ',') {
      String key = args.substring(last, i);
      key.trim();
      uint8_t code = keyFromName(key);
      if (code != 0) {
        Keyboard.press(code);
        delay(2);
      }
      last = i + 1;
    }
  }
}

void doRELEASE(const String& args) {
  int last = 0;
  for (int i = 0; i <= args.length(); i++) {
    if (i == args.length() || args[i] == ',') {
      String key = args.substring(last, i);
      key.trim();
      uint8_t code = keyFromName(key);
      if (code != 0) {
        Keyboard.release(code);
        delay(2);
      }
      last = i + 1;
    }
  }
}

void doDELAY(const String& args) {
  int ms = args.toInt();
  if (ms > 0) delay(ms);
}
