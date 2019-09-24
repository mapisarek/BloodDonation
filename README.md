# Blood donation website

Project created during classes in programming ASP.NET web technology.
The task received from the teacher was to create a website for the regional blood donation center.
The requirements were as following: the ability to enter a CSV file on the page, create validation of the entered data, and display incorrect records. As an addition to the main page, I also created a chart that is determined based on the amount of blood in a given type in the bank.

## Features

* Single main webpage informing about the basic conditions of donating blood
* Creating a chart of blood amount depending on the blood type
* The ability to enter a CSV file into the database
* Validation of all input data
* Displaying incorrect records (management page) from a CSV file that were entered and did not pass validation.

## Details

The site consists of two subpages, the main informing about the basic conditions of blood donation and displaying current statistics of the amount of blood in the database and the subpage to manage which includes the possibility of entering a CSV file. When the file is entered, data validation is carried out, the correctness of each record provided in the CSV file is checked. Incorrect data is marked in red and displayed in the table.

The order of the entered data in the CSV file: name, surname, city, ID number, blood factor, blood type, donation date.
Record delimiters are set in the Services folder and the CsvReaderService class. Currently set to ; and ,

Because of the imposed requirements, the entire frontend is presented in Polish, also data validation must be compatible with the Polish language

## Gallery

### Pictures shown below are available in a reduced resolution, full pictures are avalible in Preview folder inside repository.

<img src="https://github.com/mapisarek/BloodDonation/blob/master/Preview/MainPage.png" width=700 height=400/>
<img src="https://github.com/mapisarek/BloodDonation/blob/master/Preview/Information.png" width=700 height=400/>
<img src="https://github.com/mapisarek/BloodDonation/blob/master/Preview/Statistics.png" width=700 height=400/>
<img src="https://github.com/mapisarek/BloodDonation/blob/master/Preview/InvalidRecords.png" width=700 height=400/>
