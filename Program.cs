using class0706WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// ��� ������ �������� ������ ������� IDistributedCache, � 
// ASP.NET Core ������������� ���������� ���������� IDistributedCache
builder.Services.AddDistributedMemoryCache();// ��������� IDistributedMemoryCache
builder.Services.AddSession();  // ��������� ������� ������
var app = builder.Build();


app.UseSession();   // ��������� middleware-��������� ��� ������ � ��������

// ��������� middleware-���������� � �������� ��������� �������.
app.UseFromTenThousandToHundredThousand();//10001-100000
app.UseFromThousandToTenThousand();//1001-10000
app.UseFromHundredToThousand();//101-1000
app.UseFromTwentyToHundred();// 20-100
app.UseFromElevenToNineteen();//11-19
app.UseFromOneToTen();//1-10
app.Run();



