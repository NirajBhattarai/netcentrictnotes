# C# Array Documentation

## Table of Contents

- Introduction
- Creating Arrays
- Common Methods

## Introduction
 
  An array is a collection of items stored in contiguous memory locations. In C#, arrays are strongly-typed, meaning that they can only store elements of the same data type. The elements of an array can be accessed using their index, which starts at zero.

## Creating Arrays

  To create an array, you need to declare its data type, followed by square brackets [] and then the variable name. You can also specify the length of the array during initialization.

  ```
  int[] numbers = new int[5]; // creates an integer array of length 5
  string[] names = new string[3]; // creates a string array of length 3
  ```

  You can also initialize an array with values:

  ```
  int[] numbers = { 1, 2, 3, 4, 5 }; // creates an integer array with specified values
  string[] names = { "Alice", "Bob", "Charlie" }; // creates a string array with specified values
  ```

## Common Methods
Here is a list of common methods and properties associated with arrays in C#:

- Length: Returns the total number of elements in the array.
  ```
  int[] numbers = { 1, 2, 3, 4, 5 };
  int length = numbers.Length; // length = 5
  ```
- GetValue: Retrieves the value of the specified element in the array.
  ```
  int[] numbers = { 1, 2, 3, 4, 5 };
  int secondNumber = (int)numbers.GetValue(1); // secondNumber = 2
  ```
- SetValue: Sets the value of the specified element in the array.
  ```
  int[] numbers = { 1, 2, 3, 4, 5 };
  numbers.SetValue(6, 1); // numbers = { 1, 6, 3, 4, 5 }
  ```
- IndexOf: Searches for the specified value and returns the index of its first occurrence.
  ```
  int[] numbers = { 1, 6, 3, 4, 5 };
  int index = Array.IndexOf(numbers, 6); // index = 1
  ```
- Sort: Sorts the elements in the array.
  ```
  int[] numbers = { 5, 2, 8, 1, 3 };
  Array.Sort(numbers); // numbers = { 1, 2, 3, 5, 8 }
  ```
- Reverse: Reverses the order of the elements in the array.
  ```
  int[] numbers = { 1, 2, 3, 4, 5 };
  Array.Reverse(numbers); // numbers = { 5, 4, 3, 2, 1 }
  ```
     
  
     
  


