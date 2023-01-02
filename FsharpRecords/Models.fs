module Models

type Customer = 
    {
        firstName   :   string
        lastName    :   string
        gender      :   char
        phoneNumber :   string
        salary      :   float
    }

type Product = 
    {
        name                : string
        description         : string
        mutable quantity    : int
    }

type Person1 = 
    { 
        name: string 
        age:int 
    }

type Person2 = 
    { 
        name: string 
        age: int
    }

type Employee = 
    {
        name          : string
        age           : int
        employeeNumber: string
    }
    member this.GetFullDetails() = 
        sprintf "Employee Number: %s | Name: %s" this.employeeNumber this.name
