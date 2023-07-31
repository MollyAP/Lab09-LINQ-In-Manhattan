# Lab 09: LINQ in Manhattan
Author: Mollemira Porphura
Version: 1.0.0

## Overview
This project is a C# program that utilizes LINQ queries and Lambda expressions to read data from an external JSON file and perform various data filtering and manipulation operations. The program specifically focuses on location information for properties in Manhattan.

## Getting Started
To run the program, follow these steps:

1. Clone or download this repository to your local machine.
2. Make sure you have the required dependencies installed, including Newtonsoft.Json (NewtonSoftJson).
3. Compile and run the C# program using your preferred IDE or command-line tools.

## Example

1. Launch the program, it will automatically output all of the neighborhoods in the data list.
2. Press 2 to filter out neighborhoods that do not have any names.
3. Prees 3 to remove duplicate neighborhoods.
4. Press 4 to consolidate the queries into a single query.
5. Press 5 to do the same thing but using the the opposing method..

The results of each task will be displayed in the console.

## Architecture
The project is written in C# and utilizes LINQ queries and Lambda expressions to process the data. The `Newtonsoft.Json` (NewtonSoftJson) NuGet package is used for reading and deserializing the data from the `data.json` file.

## Change Log
- Version 1.0.0: 07/31/2023
