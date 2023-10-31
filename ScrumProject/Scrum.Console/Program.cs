using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;

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

Console.WriteLine(product.ToString());
Console.ReadLine();
