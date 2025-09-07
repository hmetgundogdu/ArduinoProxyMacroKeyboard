#include "Parser.h"
#include "Commands.h"

String trimWS(const String& s) {
  int start = 0, end = s.length() - 1;
  while (start <= end && isspace(s[start])) start++;
  while (end >= start && isspace(s[end])) end--;
  if (end < start) return "";
  return s.substring(start, end + 1);
}

void executeLine(const String& line) {
  int last = 0;
  for (int i = 0; i <= line.length(); i++) {
    if (i == line.length() || line[i] == ';') {
      String part = trimWS(line.substring(last, i));
      if (part.length() > 0) {
        executeCommand(part);
      }
      last = i + 1;
    }
  }
}

void executeCommand(const String& token) {
  int sp = token.indexOf(' ');
  String cmd = (sp < 0) ? token : token.substring(0, sp);
  String args = (sp < 0) ? "" : token.substring(sp + 1);

  cmd.toUpperCase();
  args.trim();

  if (cmd == "PRESS") {
    doPRESS(args);
  } else if (cmd == "RELEASE" || cmd == "RELASE") {
    doRELEASE(args);
  } else if (cmd == "DELAY") {
    doDELAY(args);
  }
}