# Arduino Macro Programmer

A simple and customizable macro system using **Arduino Leonardo**.  
It allows you to run keyboard macros with normal or random delays, scenario files, and a safe exit key.

## Features
- Scenario-based macro definitions  
- `DELAY` and `RANDOM_DELAY` support  
- Configurable escape key (via JSON)  
- Arduino Leonardo keyboard emulation  
- C# desktop app for loading and managing scenarios  

## Example Scenario

## Example Config (JSON)
```json
{
    "Port": "COM9",
    "EscapeKey": "Q",
    "Commands": [
        "PRESS Z",
        "RANDOM 10-100",
        "RELEASE Z",
        "RANDOM 250-500",
        "PRESS R",
        "RANDOM 10-100",
        "RELEASE R",
        "RANDOM 100-600"
    ]
}