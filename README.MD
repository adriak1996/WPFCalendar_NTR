

 ## WPF CALENDAR in MVVM standard with localDB (MS SQL 13)

### 1. Functionality
- **Common context**
	- The view of calendar always consists of 4 weeks
	- Buttons from left and right allow to move one week backward or forward.
	- Current day is highlighted in red.

-  **User context**
	- Application is called with an invidual username (username is load from file) 
	- The user can see only his own appointments in the calendar
	- He is able to add/remove/edit any appointment
	- The user can also change information about his attendance in each appointment (YES or NO)

-  **Concurrency and UX context**
	- Application support concurrency (in management of appointments and attendances) by use additional list from memory of program to compare changing record with its the prototype in the data base.
	- User is informed about possible mistakes and failures associated with concurrency.

-  **Additional features**
	- Activity of program is registred by logging procedure (Log4Net)
	- 3 fontstyles (normal, italic, oblique) 
	- 3 skins for appearance of the application (azure, gold and lightgreen) 
	- mouse rightclick pop-up to change the design
	
### 2. Credits
   - *el-gato*

### 3. Other contribution:
   - Materials from the website of the course *Rapid Applictation Developement tools*
 
______________________________________________________________________________________________________________
*Written in November/December of the 2017*

**DO NOT USE IN COMMERCIAL PURPOSES!!!**
