# Toy Robot Simulator

The console application is a simulation of a toy robot moving on a square tabletop of dimensions 5 units x 5 units

## Prerequistites
This Toy Robot Simulator requires the following:

* Visual Studio 2017
* .net framework 4.5.2 or above

## Build and run the application
1. Open the app solution in Visual Studio.
2. Press F5 to build and run the app. This will open the console application.

## Command

Here are the commands that can be used in the application.

#### PLACE X,Y,F
Arguments: 
* X: Coordinate X between 0 to 4;
* Y: Coordinate Y between 0 to 4;
* F: NORTH, SOUTH, EAST or WEST;

PLACE will put the toy robot on the table in position X,Y and facing F

Example:
```bash
PLACE 1,0,NORTH
```

#### MOVE

MOVE the robot one unit forward in the direction it is currently facing.

Example:
```bash
MOVE
```
#### LEFT

Rotate the robot -90 degress.

Example:
```bash
LEFT
```
#### RIGHT

Rotate the robot 90 degress.

Example:
```bash
RIGHT
```
#### REPORT

Announce the X,Y and F of the robot.

Example:
```bash
REPORT
```
