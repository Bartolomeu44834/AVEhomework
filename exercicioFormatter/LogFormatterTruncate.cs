using System;
class LogFormatterTruncate : AbstractFormatter {
  private int decimals {get; set;}
  public LogFormatterTruncate(int decimals) { this.decimals = decimals; }

  public LogFormatterTruncate(){
      this.decimals = 1;
  }

  public override object Format(object val) {return Math.Round((double) val, decimals);} 
}