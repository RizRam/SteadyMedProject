# SteadyMed

## Prerequisites

* Visual Studio 2017
* ASP.NET Core 2.0

## Getting Started

Navigate to SteadyMed Project root folder and start the following solutions:

1. Services:
* AccountManagementService
* MedicationPlan Service
* Profile Service
```
Open .sln file
Press Ctrl + F5
This will open a tab on your web browser.
```
2. SteadyMedDevice
```
Open .sln file
Press F5 run the program
This will open a console window that will simulate the device and output messages
```
3. SteadyMedApiGateway (It's actually the client w/ some API Gateway functionality)
```
Open .sln file
Press Ctrl + F5
This will open a tab on your web browser containing a Login page.
```

## How to do the SteadyMed Demo

1. Login to the service using a physician account.
```
Username: account1
Password: password
```
This will take you to the physician profile page, at the moment it only contains a table of all the physician's patients.

2. Select a patient by clicking on the patient's table row.
This will take you to the Patient's profile page.

3. Click on the Create Plan button to bring up a pop-up dialog.
4. Enter the details of your new medication plan.
```
Medication: Aspirin
Hourly Interval: 6
Pills Per Interval: 2
SteadyMed ID: 10 **(Note: This must be 10 for this DEMO to work)**
```
Once completed, you will be redirected to the physician profile page again.  

5. Click on the same patient to see that a new medication plan has been added to the patient's list of medication plan.
6. Look at the SteadyMed Device console window to see the new medication plan details in the console.

## Authors
* Craig Rainey
* Rizky Ramdhani
* Daniel Blashaw
* Justin Gilroy




