using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;
using ToDoList.Objects;

namespace ToDoList
{
  public class TaskTest : IDisposable
  {
    public TaskTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ToDoList_Test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Task.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Eqal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      //Arrange, Act
      Task firstTask = new Task("Mow the lawn");
      Task secondTask = new Task("Mow the lawn");

      //Assert
      Assert.Equal(firstTask, secondTask);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Task testTask = new Task("Mow the lawn");

      //Act
      testTask.Save();
      List<Task> result = Task.GetAll();
      List<Task> testList = new List<Task>{testTask};

      //Assert
      Assert.Equal(testList, result);

    }

    [Fact]
    public void Test_Save_AssignIdToObject()
    {
      //Arrange
      Task taskTest = new Task("Mow the lawn");

      //Act
      testTask.Save();
      Task savedTask = Task.GetAll()[0];

      int result = savedTask.GetId();
      int testId - testTask.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    public void Dispose()
    {
      Task.ClearAll();
    }
  }
}
