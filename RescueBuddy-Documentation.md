# Project Documentation

By Keanu Koelewijn

| Date       | Version | Summary                                                             |
| ---------- | ------- | ------------------------------------------------------------------- |
| 12-01-2024 | 0.0.1   | Initial of the project documentation.                               |
| 19-01-2024 | 0.0.2   | Completed user stories, test cases, and development considerations. |
| 26-01-2024 | 0.0.3   | updated Implementation documentation                                |
| 02-02-2024 | 0.0.4   | updated Implementation documentation                                |

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
| 5    | Optional   | Quality    | As a user, I want the app to have a good user interface for easy navigation.                                               |

### 1.3 Test Cases

| TC-№ | Initial Situation       | Input                                     | Expected Output                          |
| ---- | ----------------------- | ----------------------------------------- | ---------------------------------------- |
| 1.1  | User is on Homepage     | User presses the emergency alarm button.  | Loud alarm sound is activated.           |
| 2.1  | User is in the Settings | User adds emergency contacts in the app.  | Contacts are saved successfully.         |
| 3.1  | User is on Homepage     | Emergency alarm is triggered by the user. | App initiates calls to contacts.         |
| 4.1  | User is on Homepage     | User presses the emergency alarm button.  | App records audio locally on the device. |

### 1.4 Diagrams

![usecase demo buddy](https://github.com/Kurizaki/RescueBuddy/assets/110892283/ba76fffe-cb3f-4325-9676-0ee4dcfbbc40)

![RescueBuddy](https://github.com/Kurizaki/RescueBuddy/assets/110892283/b1d6e854-eaa5-450b-9f80-f64f3c1be67a)

## 2 Plan

| AP-№ | Deadline   | Responsible     | Description                                | Planned Time |
| ---- | ---------- | --------------- | ------------------------------------------ | ------------ |
| 1.A  | 02-02-2024 | Keanu Koelewijn | Develop the emergency alarm feature.       | 2 hours      |
| 2.A  | 02-02-2024 | Keanu Koelewijn | Integrate functionality to change contacts | 2 hours      |
| 3.A  | 02-02-2024 | Keanu Koelewijn | Integrate auto-call functionality.         | 2 hours      |
| 4.A  | 02-02-2024 | Keanu Koelewijn | Implement audio recording feature.         | 2 hours      |
| 5.A  | 26-01-2024 | Keanu Koelewijn | Implement User Interface                   | 4 hours      |
| 6.A  | 02-02-2024 | Keanu Koelewijn | Create and update Documentation            | 2 hours      |

Total: 14 work packages

## 3 Decide

I habe have decided to focus on the must-have user stories and maybe to remove the options page because of dead lines.

## 4 Implement

| AP-№ | Date       | Responsible     | Planned Time | Actual Time |
| ---- | ---------- | --------------- | ------------ | ----------- |
| 1.A  |            |                 |              |             |
| 2.A  |            |                 |              |             |
| 3.A  |            |                 |              |             |
| 4.A  | 02-02-2024 | Keanu Koelewijn | 2 hours      | 2 hours     |
| 5.A  | 26-01-2024 | Keanu Koelewijn | 4 hours      | 10 hours    |
| 6.A  | 02-02-2024 | Keanu Koelewijn | 2 hours      | 2 hours     |



## 5 Control

### 5.1 Test Report

| TC-№ | Date | Result | Tester |
| ---- | ---- | ------ | ------ |
| 1.1  |      |        |        |
| ...  |      |        |        |

✍️ Don't forget to add a conclusion that contextualizes the test result.

### 5.2 Exploratory Testing

| BR-№ | Initial Situation | Input | Expected Output | Actual Output |
| ---- | ----------------- | ----- | --------------- | ------------- |
| I    |                   |       |                 |               |
| ...  |                   |       |                 |               |

✍️ Use Roman numerals for your bug reports, so I, II, III, IV, etc.

## 6 Evaluate

✍️ Insert a link to your learning report here.

## Used Sources:
https://www.youtube.com/watch?v=80DfwQXbdaQ
https://www.youtube.com/watch?v=B-5e0PJtSDs
https://www.youtube.com/watch?v=gf6abNRAhuY
https://www.youtube.com/watch?v=dgekGX8eYMo&t=196s
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/customize?view=net-maui-7.0
https://stackoverflow.com/questions/74973199/net-maui-navigation-animation
https://www.youtube.com/watch?v=6qz-yFOVZuU
https://www.youtube.com/watch?v=civZ1wY-2oM
https://devblogs.microsoft.com/dotnet/announcing-dotnet-maui-communitytoolkit-mediaelement/
https://www.youtube.com/watch?v=KaHyRSy5sAs
https://www.youtube.com/watch?v=oIYnEuZ9oew
https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/secure-storage?view=net-maui-8.0&tabs=android
https://www.msdevbuild.com/2022/06/net-maui-store-local-data-with.html
https://www.youtube.com/watch?v=3xqIXS1SBaU
https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/permissions?view=net-maui-8.0&tabs=windows
https://www.youtube.com/watch?v=9GljgwfpiiE
https://www.youtube.com/watch?v=XRLK786Jaio
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/images/splashscreen?view=net-maui-8.0&tabs=android
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/button?view=net-maui-8.0
https://learn.microsoft.com/en-us/samples/dotnet/maui-samples/userinterface-checkbox/
https://learn.microsoft.com/de-de/dotnet/maui/user-interface/shadow?view=net-maui-8.0
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label?view=net-maui-8.0
https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/tabs?view=net-maui-8.0
https://learn.microsoft.com/de-de/dotnet/maui/fundamentals/shell/create?view=net-maui-8.0
https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/pages?view=net-maui-8.0
https://www.youtube.com/watch?v=RGdeVWQuuZI&t=417s
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/border?view=net-maui-8.0
https://learn.microsoft.com/de-de/dotnet/maui/fundamentals/shell/flyout?view=net-maui-8.0
https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/?view=net-maui-8.0
https://learn.microsoft.com/de-de/dotnet/maui/what-is-maui?view=net-maui-8.0