//This C# script has been added so that the sketch script can pull data from the table
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Make sure you get rid of the namespace that is automatically generated here.
class A3
{
    //List all the columns of your table here in the same format as below.
    public string AddedAt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ListName { get; set; }
    public string BoardName { get; set; }
    public string CreatorFullName { get; set; }
    public string CreatorUserName { get; set; }
    public string CardURL { get; set; }
}