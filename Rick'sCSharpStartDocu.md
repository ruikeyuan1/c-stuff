# Startdocument for Container rental

Startdocument of **Ruike Yuan**. Student number **5000521**.

## Problem Description
A container company rents out containers. The following prices are charged: 
The rent is € 40,- per m3 per day. Taking away a container costs € 60,- if the  volume of the container is 2 m3 or less, otherwise € 125,-.  
 A program must be developed in which the volume of the container and the 
start and end date (format ddmmyyyy) for the rental period can be entered for 
each container. The payable charges for each rented container period must be 
calculated and shown. The total income, the average volume and the longest 
rental period must also be shown cumulatively.    Read the introduction of this appendix and appendix 7.3 thoroughly.  

### Input & Output

In this section the in- and output of the application will be described.

#### INPUT
      
|Case|Type|Conditions|
|----|----|----------|
|RentalstartDate|`date`|not empty|
|RentalEndDate|`date`|not empty|
|VolumeOfContainer|`interger`|0 <`number`< 20|


#### Output

|Case|Type|
|----|----|
|The total income of company|`integer`|
|Longest rental period|`integer`|
|Average volume|`double`|
|payable charges|`double`|



#### Calculations

| Case              | Calculation                        |
| ----------------- | ---------------------------------- |
| Payable charges | The sum of all the acumulative container prices in a rental. |
| RentalPeriod | The sum of all the rental days |
| containerPrice | current price of each container |
| The total income| The sum of all the payable charges in every rental |

#### Container-rent                

| ID            | Input                             | Code                              |
| ------------- | --------------------------------- | --------------------------------- |
| `rentalOne` | id:1 <br/>startDate: 20200506<br/>endDate:20200520<br/><container>list | `new Container-rent(1, 20200506, 20200520,new container )` |
| `rentalTwo` | id:2 <br/>startDate: 20200706<br/>endDate:20200720<br/><container>list | `new Container-rent(2, 20200706, 20200720,new container)` |

 
 #### Company                

| ID            | Input                             | Code                              |
| ------------- | --------------------------------- | --------------------------------- |
| `1` | id:1 <br/><rental>list | `new Container-rent(1, 20200506, 20200520,new rental)` |

 
#### Container

| ID        | Input                                                        | Code                                               |
| --------- | ------------------------------------------------------------ | -------------------------------------------------- |
| `1`     | number: 1<br />volumeOfContainer:5m^3  | `new Customer(1, 5m^3 )`                  |
| `2` | number: 2<br />volumeOfContainer:5m^3  | `new Customer(2, 5m^3 )` |
