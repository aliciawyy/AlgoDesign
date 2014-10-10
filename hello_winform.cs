/**
  This file can be compiled with
  $gmcs -pkg:dotnet hellowindow.cs
 or
  $mcs -pkg:dotnet hellowindow.cs
  */
using System;
using System.Windows.Forms;

public class HelloWorld : Form
{
    static public void Main ()
    {
        Application.Run (new HelloWorld ());
    }

    public HelloWorld ()
    {
        Text = "Hello Mono World";
    }
}
