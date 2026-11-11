using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NoteDb>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));


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

    return note;
});

app.MapGet("/{user_id}/notes", async (int user_id, NoteDb db) =>
{
    var notes = await db.Notes.Where(note => note.UserId == user_id).ToListAsync();
    return Results.Ok(notes);
});
app.Run();

