using MicroBlog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var postRepository = new PostRepository(builder.Environment.ContentRootPath);
builder.Services.AddSingleton(postRepository);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();