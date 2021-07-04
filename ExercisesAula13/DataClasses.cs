using CustomAttributes;
namespace DataClasses{
    public record Student(
        [property:ComparisonAttribute(2)] int Nr,
        string Name,
        School School,
        [property:ComparisonAttribute(1)] string Nationality
    ) {

    }

    public record School(
        string Name,
        string Location
    ) {
       /* public override bool Equals(object obj) { 
             iguais se Name e Location iguais  
            string objName = obj.GetType.GetProperty("Name").GetValue(obj);
            string objLocation = obj.GetType.GetProperty("Location").GetValue(obj);

            return Name.Equals(objName) && Location.Equals(objLocation);
        }*/

    }
}

