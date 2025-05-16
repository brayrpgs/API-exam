# Steps to Set the Project Locally

Follow these steps to get the project up and running on your local machine:

## 1. Clone the Repository

```bash
git clone https://github.com/brayrpgs/API-exam.git
```

## 2. Locate and extract the `secrets.zip` file
This process will generate two files:  
- One containing the `.env` file configuration  
- Another containing the FCM (Firebase Cloud Messaging) configuration

## 3. Configure the Database

1. **Download** the `.SQL` file from the `data/Database` folder.  
2. **Open** SQL Server Management Studio (SSMS).  
3. **Create** a new query by clicking on **New Query**.  
4. **Open** the `database.sql` file with a text editor and **copy** all its content.  
5. **Paste** the copied content into the SSMS query window.  
6. **Execute** the query to create and configure the database.


## 4. Configure the `.env` File with Database Credentials

- Make sure you have a user named **sa** with the password **123**, with all the necessary permissions to execute queries and manage the database.  
- If you prefer to use a different user, update the `.env` file with the appropriate username and password.  
- Ensure that the SQL Server is running on port **1433**. If it's using a different port, update the `.env` file accordingly to reflect the correct port.

## 5. Build the Project

Navigate to the `../API-exam/api` directory and run the following command to build the project:

```bash
dotnet build
```

## 6. Run the API

Navigate to the `../API-exam/api` directory and run the following command to start the backend with hot reload:

```bash
dotnet watch run
```

## 7. Extra

To explore and test the API using Swagger, open the following URL in your browser:

[http://localhost:5041/swagger/](http://localhost:5041/swagger/)

