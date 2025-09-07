#include <Keyboard.h>
#include "Parser.h"

String currentLine = "";
bool lineReady = false;
unsigned long lastCommandTime = 0;
const unsigned long timeoutMs = 5000; // command timeout

void setup() {
  Serial.begin(9600);
  Keyboard.begin();
  delay(1200); // HID tanınsın
}

void loop() {
  // execute commands
  if (lineReady) {
    executeLine(currentLine);
    currentLine = "";
    lineReady = false;
    lastCommandTime = millis();
  }

  // read commands from manager
  while (Serial.available() > 0) {
    char c = (char)Serial.read();
    if (c == '\n') {
      lineReady = true;
    } else {
      currentLine += c;
      if (currentLine.length() > 512) {
        currentLine.remove(0, currentLine.length() - 512);
      }
    }
  }

  // timeout control
  if (millis() - lastCommandTime > timeoutMs) {
    Keyboard.releaseAll();
    lastCommandTime = millis();
  }
}
