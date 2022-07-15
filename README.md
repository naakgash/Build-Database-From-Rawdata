# Raw Movie Data to Relational Database

- The purpose of this project is to build a relational database using movie data exported in .csv format.

## What are the challenges?
- While singular values such as title, budget, rate can be easily transferred to PostgreSQL as column information in movie data in .csv format, information such as Genre, Collection, Country that are in many-to-many relationships with the Movie table and in json format cannot be transferred without preserving the relationship information.

## Solution
- Converting raw data to relational data using Entity framework core and any json deserialize tool.

## Usage
- **First, we run PostgreSQL with pgAdmin.**
- **Next, we click (Databases -> Create -> Database..)**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/1.png" alt="drawing" width="500"/>

- **Next, we set the Database name as 'IMDB' and click Save.**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/2.png" alt="drawing" width="500"/>

- **Then, we right click on the IMDB database we created, click CREATE Script.**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/3.png" alt="drawing" width="500"/>

- **In the window that opens, paste the code below in the 'Query' section.**

```
CREATE TABLE rawdata(
   adult                 BOOLEAN NOT NULL
  ,belongs_to_collection VARCHAR(184)
  ,budget                BIGINT NOT NULL
  ,genres                VARCHAR(264) NOT NULL
  ,homepage              VARCHAR(242)
  ,id                    BIGINT  NOT NULL 
  ,imdb_id               VARCHAR(9)
  ,original_language     VARCHAR(5)
  ,original_title        VARCHAR(109) NOT NULL
  ,overview              VARCHAR(1000)
  ,popularity            FLOAT
  ,poster_path           VARCHAR(35)
  ,production_companies  VARCHAR(1252)
  ,production_countries  VARCHAR(1039)
  ,release_date          timestamp with time zone
  ,revenue               BIGINT 
  ,runtime               NUMERIC(6,1)
  ,spoken_languages      VARCHAR(765)
  ,status                VARCHAR(15)
  ,tagline               VARCHAR(297)
  ,title                 VARCHAR(105)
  ,video                 VARCHAR(5)
  ,vote_average          NUMERIC(4,1)
  ,vote_count            INTEGER 
);
```

- **Then, click 'Execute/Refresh'..**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/4.png" alt="drawing" width="650"/>

- **Then we find the rawdata table via (Databases - > IMDB -> Schemas -> Tables) and right click and click 'Import/Export Data'.**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/5.png" alt="drawing" width="350"/>

#### In the tab that opens, respectively;
- Select IMPORT,
- Show file path 'movies_metadata.csv',
- Open the 'Header' section,
- Select comma(,) as delimiter,
- Close the Quote and Escape parts,
- Then, click 'Ok'.

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/6.png" alt="drawing" width="450"/>

---

> **The 'movies_metadata.csv' file is in **csv** folder in github repository.** 
> **After extracting the .rar compressed file, it should be used as .csv.**
> **In order for the file to be read correctly, the file in the repository on which I have made improvements should be used.**

---

#### ***Movies data was saved in the rawdata table, now let's go to the program and make this data relational with the related tables.***

- **First, download the repo to your computer and run the data.sln file in the data folder. The program will open with Visual Studio.**

- **Then open the IMDBContext file and enter the username and password you use for PostgreSQL.**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/7.png" alt="drawing" width="1000"/>

- **Then run the 'Package Manager Console' from (Tools -> NuGet Package Manager).**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/8.png" alt="drawing" width="700"/>

- **Then write 'update-database' in the opened tab and press 'Enter'.**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/8a.png" alt="drawing" width="700"/>

- **Next, run the program. A counter will start counting down when the program starts running. This process may take some time.**

<img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/9.png" alt="drawing" width="700"/>

- **After the process is completed, our tables on PostgreSQL are ready.**

<div align="left"><p><img src="https://github.com/naakgash/Build-Database-From-Rawdata/blob/main/pics/tables.gif" width="600px">

> **The API project I created using these tables can be accessed from the link below, thank you.**

> [Arvato-Restful-API](https://github.com/naakgash/Arvato-Restful-API)
