# Properties 

Properties are a convenient way to expose fields of a class or struct while providing encapsulation, meaning that they hide the details of how the data is stored and manipulated from the outside world. Properties enable a class to expose a public way of getting and setting values while hiding the implementation details.

## Syntax definition

```
<modifiers> <data_type> <property_name>
{
    get { return <backing_field>; }
    set { <backing_field> = value; }
}
```

## Explanation of the syntax elements

- `<modifiers>`: The access modifiers for the property (e.g., public, private, protected, or internal). 
- `<data_type>`: The data type of the property (e.g., string, int, double, or a custom type).
- `<property_name>`: The name of the property, following the naming conventions for properties in C#.
- `<backing_field>`: The name of the backing field associated with the property, usually in the form of _fieldName (e.g., _name, _age, or _major).

## Example
 
 Here's a breakdown of the Name property from the provided example:

- public: The access modifier, which makes the property accessible from any class.
- string: The data type of the property, which is a string in this case.
- Name: The property name, following the PascalCase naming convention for properties in C#.
- _name: The backing field associated with the property. This field stores the actual value of the property.

```
public string Name
{
    get { return _name; }
    set { _name = value; }
}
```
