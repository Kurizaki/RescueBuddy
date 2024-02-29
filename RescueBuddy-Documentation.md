# Project Documentation

By Keanu Koelewijn

| Date       | Version | Summary                                                             |
| ---------- | ------- | ------------------------------------------------------------------- |
| 12-01-2024 | 0.0.1   | Initial of the project documentation.                               |
| 19-01-2024 | 0.0.2   | Completed user stories, test cases, and development considerations. |
| 26-01-2024 | 0.0.3   | updated Implementation documentation                                |
| 02-02-2024 | 0.0.4   | updated Implementation documentation                                |
| 29-02-2024 | 0.0.5   | updated Implementation documentation and run tests                  |

## 1 Inform

### 1.1 Your Project

RescueBuddy is a standalone, offline personal safety app designed to offer users a reliable and secure tool to seek help during emergencies, irrespective of their internet connectivity.

### 1.2 User Stories

| US-№ | Dependency | Type       | Description                                                                                                                |
| ---- | ---------- | ---------- | -------------------------------------------------------------------------------------------------------------------------- |
| 1    | Must       | Functional | As a user, I want to trigger an emergency alarm so that nearby individuals can be alerted.                                 |
| 2    | Must       | Functional | As a user, I want to save multiple emergency contacts for quick access during emergencies.                                 |
| 3    | Must       | Functional | As a user, I want the app to automatically initiate calls to my predefined emergency contacts when the alarm is triggered. |
| 4    | Must       | Functional | As a user, I want the app to record audio evidence during emergencies for legal purposes.                                  |
| 5    | Must       | Functional | As a user, I want to navigate to my previos audio recordings to see them.                                                  |
| 6    | Optional   | Quality    | As a user, I want the app to have a good user interface for easy navigation.                                               |

### 1.3 Test Cases

| TC-№ | Initial Situation       | Input                                     | Expected Output                          |
| ---- | ----------------------- | ----------------------------------------- | ---------------------------------------- |
| 1.1  | User is on Homepage     | User presses the emergency alarm button.  | Loud alarm sound is activated.           |
| 2.1  | User is in the Settings | User adds emergency contacts in the app.  | Contacts are saved successfully.         |
| 3.1  | User is on Homepage     | Emergency alarm is triggered by the user. | App initiates calls to contacts.         |
| 4.1  | User is on Homepage     | User presses the emergency alarm button.  | App records audio locally on the device. |
| 5.1  | User is on Logpage      | User presses his wished Log file.         | Date, length and audio file is shown.    |

### 1.4 Diagrams

![FireShot Capture 003 - RescueBuddy – Figma - www figma com](https://github.com/Kurizaki/RescueBuddy/assets/110892283/606d5a14-2cbe-471c-8540-c7986479a88d)
![usecase demo buddy](https://github.com/Kurizaki/RescueBuddy/assets/110892283/e7acd67f-411d-4a18-8ee6-4e9446f11e33)

## 2 Plan


| AP-№ | Deadline   | Responsible     | Description                                | Planned Time |
| ---- | ---------- | --------------- | ------------------------------------------ | ------------ |
| 1.A  | 02-02-2024 | Keanu Koelewijn | Develop the emergency alarm feature.       | 2 hours      |
| 2.A  | 02-02-2024 | Keanu Koelewijn | Integrate functionality to change contacts | 2 hours      |
| 3.A  | 02-02-2024 | Keanu Koelewijn | Integrate auto-call functionality.         | 2 hours      |
| 4.A  | 02-02-2024 | Keanu Koelewijn | Implement audio recording feature.         | 2 hours      |
| 5.A  | 02-02-2024 | Keanu Koelewijn | Implement Log and file navigation.         | 2 hours      |
| 6.A  | 26-01-2024 | Keanu Koelewijn | Implement User Interface                   | 4 hours      |
| 7.A  | 02-02-2024 | Keanu Koelewijn | Create and update Documentation            | 2 hours      |

Total: 14 work packages

## 3 Decide

I habe have decided to focus on the must-have user stories and maybe to remove some features on the options page because of dead lines.

## 4 Implement

| AP-№ | Date       | Responsible     | Planned Time | Actual Time |
| ---- | ---------- | --------------- | ------------ | ----------- |
| 1.A  | 22-02-2024 | Keanu Koelewijn | 2 hours      | 3 hours     |
| 2.A  | 22-02-2024 | Keanu Koelewijn | 2 hours      | 3 hours     |
| 3.A  | 22-02-2024 | Keanu Koelewijn | 2 hours      | 4 hours     |
| 4.A  | 02-02-2024 | Keanu Koelewijn | 2 hours      | 2 hours     |
| 5.A  | 29-02-2024 | Keanu Koelewijn | 2 hours      | 4 hours     |
| 6.A  | 26-01-2024 | Keanu Koelewijn | 4 hours      | 10 hours    |
| 7.A  | 02-02-2024 | Keanu Koelewijn | 2 hours      | 2 hours     |



## 5 Control

### 5.1 Test Report

| TC-№ | Date       | Result | Tester          |
| ---- | ---------- | ------ | --------------- |
| 1.1  | 29-02-2024 | OK     | Keanu Koelewijn |
| 2.1  | 29-02-2024 | OK     | Keanu Koelewijn |
| 3.1  | 29-02-2024 | OK     | Keanu Koelewijn |
| 4.1  | 29-02-2024 | OK     | Keanu Koelewijn |
| 5.1  | 29-02-2024 | NOK    | Keanu Koelewijn |

The tests did not run smoothly, all tests were successfully executed except the last test, the logs are saved but only displayed when the programme is restarted, and the information is not displayed correctly.

## 6 Evaluate

✍️ Insert a link to your learning report here.

## Used Sources:

https://www.youtube.com/watch?v=80DfwQXbdaQ <br>
https://www.youtube.com/watch?v=B-5e0PJtSDs <br>
https://www.youtube.com/watch?v=gf6abNRAhuY <br>
https://www.youtube.com/watch?v=dgekGX8eYMo&t=196s
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/customize?view=net-maui-7.0 <br>
https://stackoverflow.com/questions/74973199/net-maui-navigation-animation <br>
https://www.youtube.com/watch?v=6qz-yFOVZuU <br>
https://www.youtube.com/watch?v=civZ1wY-2oM <br>
https://devblogs.microsoft.com/dotnet/announcing-dotnet-maui-communitytoolkit-mediaelement/ <br>
https://www.youtube.com/watch?v=KaHyRSy5sAs <br>
https://www.youtube.com/watch?v=oIYnEuZ9oew <br>
https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/secure-storage?view=net-maui-8.0&tabs=android <br>
https://www.msdevbuild.com/2022/06/net-maui-store-local-data-with.html <br>
https://www.youtube.com/watch?v=3xqIXS1SBaU <br>
https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/permissions?view=net-maui-8.0&tabs=windows <br>
https://www.youtube.com/watch?v=9GljgwfpiiE <br>
https://www.youtube.com/watch?v=XRLK786Jaio <br>
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/images/splashscreen?view=net-maui-8.0&tabs=android <br>
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/button?view=net-maui-8.0 <br>
https://learn.microsoft.com/en-us/samples/dotnet/maui-samples/userinterface-checkbox/ <br>
https://learn.microsoft.com/de-de/dotnet/maui/user-interface/shadow?view=net-maui-8.0 <br>
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label?view=net-maui-8.0 <br>
https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/tabs?view=net-maui-8.0 <br>
https://learn.microsoft.com/de-de/dotnet/maui/fundamentals/shell/create?view=net-maui-8.0 <br>
https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/pages?view=net-maui-8.0 <br>
https://www.youtube.com/watch?v=RGdeVWQuuZI&t=417s <br>
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/border?view=net-maui-8.0 <br>
https://learn.microsoft.com/de-de/dotnet/maui/fundamentals/shell/flyout?view=net-maui-8.0 <br>
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/?view=net-maui-8.0 <br>
https://learn.microsoft.com/de-de/dotnet/maui/what-is-maui?view=net-maui-8.0 <br>
