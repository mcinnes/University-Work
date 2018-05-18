#warning Please use a terminal emulator that supports colours to run this application correctly
/*
 SIT172 Assignment 3
 
 Author : Matt McInnes
 Student ID: 214119048
 Date : 23/8/2016
 Function: Read the contents of a file into the data structure.
 Grade: 97.7
 Compile: gcc -o main main.cpp
 */
#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <math.h>       /* round, floor, ceil, trunc */


// Declared constants
// Name of file that stores our raw data
#define FILE_NAME "./data-1.csv"


// Data size
#define MAX_ROWS 19
#define MAX_COLUMNS 19
#define MAX_RANGE 5

// Debug switch ('1' for debug ON, '0' for debug OFF)
#define DEBUG 0

//Define colours for a nicer output
#define RED   "\x1B[31m"
#define GRN   "\x1B[32m"
#define YEL   "\x1B[33m"
#define BLU   "\x1B[34m"
#define RESET "\x1B[0m"

//
#define DECIMAL_PLACES 2

//In C we need to define a function
float roundValue(float value, int decimalPlaces);

// Main entry point for the program
int main(void)
{
    // Decalred variables
    int rowIndex = 0;
    int columnIndex = 0;
    float rawData[MAX_ROWS][MAX_COLUMNS]; // 2-dimensional array to store our raw data
    
    //Range Values
    float rangeValue1 = 0.4;
    float rangeValue2 = 0.8;
    float rangeValue3 = 1.2;
    float rangeValue4 = 1.6;
    float rangeValue5 = 2.0;
    
    //error map variables
    float errorMap[MAX_ROWS][MAX_COLUMNS];
    
    //classification map variables
    float classificationMap[MAX_ROWS][MAX_COLUMNS];
    
    //Display Values
    int displayValue1 = 1;
    int displayValue2 = 2;
    int displayValue3 = 3;
    int displayValue4 = 4;
    int displayValue5 = 5;
    
    // To store the counts
    int rangeCount1 = 0;
    int rangeCount2 = 0;
    int rangeCount3 = 0;
    int rangeCount4 = 0;
    int rangeCount5 = 0;
    
    //Pattern Match
    char PATTERN_A_CHAR [2]= "A";
    char PATTERN_B_CHAR [2]= "B";
    char PATTERN_C_CHAR [2]= "C";
    // float NO_PATTERN_CHAR = 0;
    //char EMPTY_CHAR = ' ';
    
    //Arrays to store the pattern maps
    float patternMapA[MAX_ROWS][MAX_COLUMNS];
    float patternMapB[MAX_ROWS][MAX_COLUMNS];
    float patternMapC[MAX_ROWS][MAX_COLUMNS];
    
    //Map values
    int mapValue = 0;
    int mapValue1 = 0;
    int mapValue2 = 0;
    int mapValue3 = 0;
    
    //Pattern counts in the form of pattern_A_Count[Number1Counts][CountValue]
    float pattern_A_Count[MAX_RANGE][1];
    float pattern_B_Count[MAX_RANGE][1];
    float pattern_C_Count[MAX_RANGE][1];
    
    // Misc variables used for reading the data from the file
    float tempfloat = 0.0F;
    char newline = ' ';
    float value = 0;
    
    int count = 0;

    
    //Open the file defined in FILE_NAME in read mode
    FILE *infp;
    infp = fopen(FILE_NAME, "r");
    
    // Check for errors and exit if found
    if (infp == NULL)
    {
        printf("Error: failed to open %s for reading\n", FILE_NAME);
        return(1);
    }
    
    // Read the file into the data structure
    for (rowIndex = 0; rowIndex < 20; rowIndex++)
    {
        // Read up until the last value
        for (columnIndex = 0; columnIndex < MAX_COLUMNS; columnIndex++)
        {
            if (fscanf (infp, "%f,", &tempfloat) != EOF)
            {
                rawData[rowIndex][columnIndex] = tempfloat;
            }
            else
            {
                printf("Error: incorrect file format at row %d, col %d.\n", rowIndex + 1, columnIndex + 1);
                return(1);
            }
        }
        
        // Read the last value and the newline char
        if (fscanf (infp, "%f%c", &tempfloat, &newline) != EOF)
        {
            // Check if the last character in the line was a newline char otherwise an error occured
            if (newline != '\0' && newline != '\n' && newline != '\r')
            {
                printf("Error: incorrect file format at line %d. did not find a newline.\n", rowIndex + 1);
                return(1);
            }
            else
            {
                rawData[rowIndex][columnIndex] = tempfloat;
            }
            
            // Reset the character before the next read
            newline = ' ';
        }
    }
    
    // Close the file
    fclose(infp);
    
    
    
    
    // Print out the raw data read from the file
    if (DEBUG == 0)
    {
        printf(" --- RAW DATA ---\n");
        for (rowIndex = 0; rowIndex <=MAX_ROWS; rowIndex++)
        {
            // Read up until the last value
            for (columnIndex = 0; columnIndex <=MAX_COLUMNS; columnIndex++)
            {
                printf("%.5f ", rawData[rowIndex][columnIndex]);
            }
            printf("\n");
        }
    }
    
    
    
    //Classification map
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            //Print number befor debugging
            if (DEBUG == 1){
                printf("Going in raw %.5f \n", rawData[rowIndex][columnIndex]);
            }
            //Round the value using the function roundValue
            value = roundValue(rawData[rowIndex][columnIndex], DECIMAL_PLACES);
            
            //Print rounded value, used for debugging
            if (DEBUG == 1){
                printf("Value: %0.1f \n", value);
            }
            
            count++;
            
            //Change values into the display values as per instructions
            if (value <= rangeValue1) {
                classificationMap[rowIndex][columnIndex] = displayValue1;
                rangeCount1++;
            } else if (value <= rangeValue2) {
                classificationMap[rowIndex][columnIndex] = displayValue2;
                rangeCount2++;
            } else if (value <= rangeValue3) {
                classificationMap[rowIndex][columnIndex] = displayValue3;
                rangeCount3++;
            } else if (value <= rangeValue4) {
                classificationMap[rowIndex][columnIndex] = displayValue4;
                rangeCount4++;
            } else if (value <= rangeValue5){
                classificationMap[rowIndex][columnIndex] = displayValue5;
                rangeCount5++;
            }
            
            //Print output of each number, used for debugging
            if (DEBUG == 1){
                printf("Its classified %f \n", classificationMap[rowIndex][columnIndex]);
                printf("Count:%i \n\n", count);
            }
        }
    }
    
    //Print Classification Map
    printf("\n --- CLASSIFICATION MAP ---\n");
    
    for (rowIndex = 0; rowIndex < MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex < MAX_COLUMNS; columnIndex++){
            //Print each element of the classification map
            printf("%.0f ", classificationMap[rowIndex][columnIndex]);
        }
        //print new line at the end of each row
        printf("\n");
    }
    
    //Print Ranges
    printf("\n ---Classification Counts --- \n");
    
    printf("----------------------------------\n");
    printf(BLU"| Range   | Display Value | Count |\n" RESET);
    printf("----------------------------------\n");
    printf("| 0.0-0.4 |       1       |  %i   |\n", rangeCount1);
    printf("| 0.4-0.8 |       2       |  %i   |\n", rangeCount2);
    printf("| 0.8-1.2 |       3       |  %i   |\n", rangeCount3);
    printf("| 1.2-1.6 |       4       |  %i   |\n", rangeCount4);
    printf("| 1.6-2.0 |       5       |  %i   |\n", rangeCount5);
    printf("----------------------------------\n");
    
    
    //Begin Error map
    
    for (rowIndex = 0; rowIndex < MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex < MAX_COLUMNS; columnIndex++){
            //round raw data values to find which ones are higher or lower than our desired values
            value = roundValue(rawData[rowIndex][columnIndex], DECIMAL_PLACES);
            if (value > rangeValue5) {
                //if less than the highest acceptable number add to the error map
                errorMap[rowIndex][columnIndex] = rawData[rowIndex][columnIndex];
            }
            if (value > rangeValue1) {
                //if the rounded number is lower changed it to the highest acceptable number then add it to the error map
                value = rangeValue1;
                errorMap[rowIndex][columnIndex] = rawData[rowIndex][columnIndex];
            }
        }
    }
    
    //Print error map
    printf("\n ---Error Map --- \n");
    
    for (rowIndex = 0; rowIndex < MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex < MAX_COLUMNS; columnIndex++){
            printf("%.0f ", errorMap[rowIndex][columnIndex]);
        }
        printf("\n");
    }
    printf("\n\n");
    
    //End Error map
    
    
    //Pattern search
    //Pattern A
    
    bool first = 1;
    
    //re use count variable as the previous count has been finished
    count = 0;
    
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            
            mapValue = classificationMap[rowIndex][columnIndex];
            mapValue1 = classificationMap[rowIndex][columnIndex + 1];
            mapValue2 = classificationMap[rowIndex+1] [columnIndex+1];
            mapValue3 = classificationMap[rowIndex + 1][columnIndex];
            //Print map data, used for debugging
            if (DEBUG == 1) {
                printf("mapValue: %f\n", classificationMap[rowIndex][columnIndex]);
                printf("mapValue1: %f\n", classificationMap[rowIndex][columnIndex + 1]);
                printf("mapValue2: %f\n", classificationMap[rowIndex + 1][columnIndex + 1]);
                printf("mapValue3: %f\n", classificationMap[rowIndex + 1][columnIndex]);
                printf("count:%i\n\n", count);
            }
            
            if (mapValue == mapValue1 & mapValue == mapValue2 & mapValue == mapValue3) {
                //if a pattern has been found add it to the array and increase the count
                patternMapA[rowIndex][columnIndex] = mapValue;
                pattern_A_Count[mapValue][0]++;
                
            } else {
                //if no pattern is found then make the array value 0.0, this is done for simplicity of printing
                patternMapA[rowIndex][columnIndex] = 0.0;
            }
            count++;
        }
    } //End row for loop
    
    
    
    //Print patternmap a
    printf("\n ---Pattern A Map --- \n");
    
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            if (patternMapA[rowIndex][columnIndex] != 0.0) {
                printf(RED "%s%.0f " RESET, PATTERN_A_CHAR, patternMapA[rowIndex][columnIndex]);
            } else {
                printf("%.0f  ", classificationMap[rowIndex][columnIndex]);
            }
        }
        printf("\n");
        
    }
    //End pattern map A
    
    //Pattern map B
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            //mapValue = NAN;
            
            mapValue = classificationMap[rowIndex][columnIndex];
            mapValue1 = classificationMap[rowIndex +1][columnIndex];
            mapValue2 = classificationMap[rowIndex + 2] [columnIndex];
            
            if (first == 0) {
                printf("mapValue: %f\n", classificationMap[rowIndex][columnIndex]);
                printf("mapValue1: %f\n", classificationMap[rowIndex][columnIndex + 1]);
                printf("mapValue2: %f\n", classificationMap[rowIndex + 1][columnIndex + 1]);
                printf("mapValue3: %f\n", classificationMap[rowIndex + 1][columnIndex]);
                printf("count:%i\n\n", count);
            }
            
            if (mapValue == mapValue1 & mapValue == mapValue2) {
                
                patternMapB[rowIndex][columnIndex] = mapValue;
                
                //What is this? check variables as well
                pattern_B_Count[mapValue][0]++;
            } else {
                patternMapB[rowIndex][columnIndex] = 0.0;
            }
            count++;
            //first = 1;
        }
    } //End row for loop
    
    
    
    
    printf("\n ---Pattern B Map --- \n");
    
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            if (patternMapB[rowIndex][columnIndex] != 0.0) {
                printf(RED "%s%.0f " RESET, PATTERN_B_CHAR, patternMapB[rowIndex][columnIndex]);
            } else {
                printf("%.0f  ", classificationMap[rowIndex][columnIndex]);
            }
        }
        printf("\n");
        
    }
    
    //PAttern map C
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            //mapValue = NAN;
            
            mapValue = classificationMap[rowIndex][columnIndex];
            mapValue1 = classificationMap[rowIndex][columnIndex + 1];
            mapValue2 = classificationMap[rowIndex] [columnIndex + 2];
            
            if (first == 0) {
                printf("mapValue: %f\n", classificationMap[rowIndex][columnIndex]);
                printf("mapValue1: %f\n", classificationMap[rowIndex][columnIndex + 1]);
                printf("mapValue2: %f\n", classificationMap[rowIndex + 1][columnIndex + 1]);
                printf("mapValue3: %f\n", classificationMap[rowIndex + 1][columnIndex]);
                printf("count:%i\n\n", count);
            }
            
            if (mapValue == mapValue1 & mapValue == mapValue2) {
                
                patternMapC[rowIndex][columnIndex] = mapValue;
                
                //What is this? check variables as well
                pattern_C_Count[mapValue][0]++;
            } else {
                patternMapC[rowIndex][columnIndex] = 0.0;
            }
            count++;
            //first = 1;
        }
    } //End row for loop
    
    
    
    
    printf("\n ---Pattern C Map --- \n");
    
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            if (patternMapC[rowIndex][columnIndex] != 0.0) {
                printf(RED "%s%.0f " RESET, PATTERN_C_CHAR, patternMapC[rowIndex][columnIndex]);
            } else {
                printf("%.0f  ", classificationMap[rowIndex][columnIndex]);
            }
        }
        printf("\n");
    } // End print
    
    
    
    //Print the combined pattern map
    printf("\n ---Pattern Final Map --- \n");

    
    for (rowIndex = 0; rowIndex <= MAX_ROWS; rowIndex++) {
        for (columnIndex = 0; columnIndex <= MAX_COLUMNS; columnIndex++){
            if (patternMapA[rowIndex][columnIndex] != 0.0) {
                //If there is a value other than 0.0 print the pattern char and value
                printf(RED "%s%.0f " RESET, PATTERN_A_CHAR, patternMapA[rowIndex][columnIndex]);
            } else if (patternMapB[rowIndex][columnIndex] != 0.0) {
                //If there is a value other than 0.0 print the pattern char and value
                printf(BLU "%s%.0f " RESET, PATTERN_B_CHAR, patternMapB[rowIndex][columnIndex]);

            } else if (patternMapC[rowIndex][columnIndex] != 0.0) {
                //If there is a value other than 0.0 print the pattern char and value
                printf(GRN "%s%.0f " RESET, PATTERN_C_CHAR, patternMapC[rowIndex][columnIndex]);

            } else {
                //if there was no pattern in that location print the value from the classification map
                printf("%.0f  ", classificationMap[rowIndex][columnIndex]);
                
            }
        }
        printf("\n\n");
        
    } // End print
    
    
  //Print the pattern count values
    printf("\n ---Pattern Map Counts --- \n");

    for (int i = 0; i <= 5; i++) {
        printf("A %d: %0.f \n", i, pattern_A_Count[i][0]);
        printf("B %d: %0.f \n", i, pattern_B_Count[i][0]);
        printf("C %d: %0.f \n", i, pattern_C_Count[i][0]);
        printf("\n");
    }
    
    exit(0);
}

//Function to round the raw data to a more usable value
float roundValue(float value, int decimalPlaces) {
    
    //uses the floor function from math.h
    value = floor(value * 10.0f) / 10.0f;
    
    return value;
}

