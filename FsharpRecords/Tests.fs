module Tests

open System
open Xunit
open Microsoft.FSharp.Reflection
open Models

(* Let's create a new Record type*)
[<Fact>]
let ``Create A New Record`` () =
    let customer =  
        {
            firstName   = "Jin Vincent"
            lastName    = "Necesario"
            gender      = 'M'
            phoneNumber = "639551912324"
            salary      = 160000.0
        }
    (* Full namespace: Microsoft.FSharp.Reflection.FSharpType.IsRecord *)
    Assert.True(FSharpType.IsRecord(customer.GetType()))

(* Let's try to get the record type details and print something out *)
[<Fact>]
let ``Get Details of the Record Type``() = 
    let customer =  
        {
            firstName   = "Jin Vincent"
            lastName    = "Necesario"
            gender      = 'M'
            phoneNumber = "639551912324"
            salary      = 160000.0
        }
    
    Assert.Equal("JIN VINCENT".ToUpper(), customer.firstName.ToUpper())
    Assert.Equal("JIN VINCENT NECESARIO", 
            sprintf "%s %s" (customer.firstName.ToUpper()) (customer.lastName.ToUpper()))
    
 (* Let's try to update the record type and check if values have successfully been updated *)  
[<Fact>]
let ``Update A Record`` () = 
    let customer =                        
        {
            firstName   = "Jin Vincent"
            lastName    = "Necesario"
            gender      = 'M'
            phoneNumber = "639551912324"
            salary      = 160000.0
        }

    let rhian = { customer with firstName = "Ma. Florian"; gender = 'F' }

    Assert.Equal("Ma. Florian", rhian.firstName)
    Assert.Equal("MA. FLORIAN NECESARIO", 
            sprintf "%s %s" (rhian.firstName.ToUpper()) (rhian.lastName.ToUpper()))

[<Fact>]
let ``Update a Mutable Record Field`` () = 
    let product = 
        {
          name = "Porsche"
          description = "Sports Car"
          quantity = 10
        }
    (* Let's check if the value is still 10 before we update it into 15*)
    Assert.Equal(10, product.quantity)

    (* Update the value to 15*)
    product.quantity <- 15
    
    (* The quantity value now should be 15*)
    Assert.True(product.quantity = 15)

[<Fact>]
let ``Field Label Declarations``() = 
    
    let p1 = { Person1.name = "Tony Starks" 
               Person1.age = 48 }

    let p2 = { Person2.name = "Logan" 
               age = 200 }

    Assert.Equal("Person1", p1.GetType().Name)
    Assert.Equal("Person2", p2.GetType().Name)

    Assert.Equal("Tony Starks", p1.name)
    Assert.Equal("Logan", p2.name)

[<Fact>]
let ``Create a New Record with Members`` () = 

    let myEmployee = {
        name = "Bruce Wayne"
        age = 50 
        employeeNumber = "BATMAN01"
    }

    let details = myEmployee.GetFullDetails() 
    
    Assert.Equal("Employee Number: BATMAN01 | Name: Bruce Wayne", details)

 (* get the labels as a list of strings*)  
 (*
 https://stackoverflow.com/questions/58979038/get-record-type-labels-as-a-list-of-strings
 *)
    




    

    
