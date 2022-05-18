# Mars Rover Tech Test

## Summary

The project is created using a react SPA template created in Visual Studio 2022. 
To run the project download the files from git, open and run within Visual Studio 2022

initial error on SPA due to running node v16.14.2
Cannot find module 'babel-eslint'
was solved with
npm install babel-eslint --save-dev


### Additional Refinements
- Create proper error testing for malformed csv files
- Create reset button to retry the test
- Improve grid styling, prevent resizing cells
- Save CSVs to Azure storage
- Save tests to state management, so can be rerun
- Add manual mode to move rovers around with keyboard
- Save movements from manual mode into csv
- Finish animations, add step forward and step back through test


### Steps to Creating Mars Rover Tech Test
- Created Project Frontend Structure
- Create Grid to display results
- Create CSV File Upload System
- Process csv File into list of co-ordinates and directions
- Add tests around the processing
- Return data to Frontend
- Display results in the front end
- Display result in frontend grid