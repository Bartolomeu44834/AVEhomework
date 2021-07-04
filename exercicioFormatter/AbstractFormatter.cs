abstract class AbstractFormatter : IFormatter {

  public AbstractFormatter(){
      
  }

  public virtual object Format(object val) {return val;} 
}