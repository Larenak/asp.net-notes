using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PracticeWebApp.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NoteDb>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


WebApplication app = builder.Build();

app.MapPost("/create", async (NoteDb db, CreateNote user_note) =>
{
    var note = new Note
    {
        UserId = user_note.UserId,
        Header = user_note.Header,
        Text = user_note.Text,
        Date = DateTime.UtcNow
    };
    db.Add(note);
    await db.SaveChangesAsync();

    return Results.Ok(note);
});

app.MapGet("/{user_id}/notes", async (int user_id, NoteDb db) =>
{
    List<Note> notes = await db.Notes.Where(note => note.UserId == user_id).ToListAsync();
    return Results.Ok(notes);
});

app.MapPost("/registration", async (NoteDb db, UserCreate create_user) =>
{

    if (string.IsNullOrWhiteSpace(create_user.Name))
    {
        return Results.BadRequest("Name is empty!");
    }
    if (string.IsNullOrWhiteSpace(create_user.Password))
    {
        return Results.BadRequest("Password is empty!");
    }
    var user = new User
    {
        Name = create_user.Name,
    };

    var hasher = new PasswordHasher<User>();
    user.PasswordHash = hasher.HashPassword(user, create_user.Password);

    db.Add(user);
    await db.SaveChangesAsync();

    return Results.Ok("User successfully created!");
});

app.MapPost("/login", async (NoteDb db, UserLogin login) =>
{
    var user = await db.Users.FirstOrDefaultAsync(u => u.Name == login.Name);
    if (user == null)
    {
        return Results.Problem("Wrong username or password!", statusCode: 401);
    }
    var hashwer = new PasswordHasher<User>();

    var result = hashwer.VerifyHashedPassword(user, user.PasswordHash, login.Password);
    if (result == PasswordVerificationResult.Failed)
    {
        return Results.Unauthorized();
    }
    return Results.Ok("Successful login!");
});

app.Run();

