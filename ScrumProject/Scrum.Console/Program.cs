using ScrumProject.Domain.Members;
using ScrumProject.Domain.Members.Enums;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;

var backDeveloper = new Member("Molayi", MemberType.BackEndDeveloper);
var frontDeveloper = new Member("Masoud", MemberType.FrontDeveloper);
var po = new Member("Soheil", MemberType.PO);

var productTitle = new ProductTitle("OMS");
var createDate = DateTime.Now;
var deadLineDate = DateTime.Now.AddYears(1);

var product = new Product(productTitle, createDate, deadLineDate);
product.AddNewRelease("ReleaseOneForOMS");

var release = product.Releases.FirstOrDefault(x => x.Title.Equals("ReleaseOneForOMS"));
var releaseFromDate = DateTime.Now;
var releaseToDate = DateTime.Now.AddDays(21);
release.AddNewSprint("SprintOneFor_ReleaseOneForOMS", releaseFromDate, releaseToDate);

var sprint = release.Sprints.FirstOrDefault(x => x.Title.Equals("SprintOneFor_ReleaseOneForOMS"));
string backLogTitle = "Fall1402";
string backLogDescription = "This is very important";
sprint.AddNewBackLog(backLogTitle, backLogDescription);

var backLog = sprint.BackLogs.FirstOrDefault(x => x.Title.Equals("Fall1402"));
backLog.AssignTo(backDeveloper.Id);

Console.WriteLine(product.ToString());
Console.ReadLine();
