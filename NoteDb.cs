using Microsoft.EntityFrameworkCore;
public class NoteDb : DbContext
{
    public NoteDb(DbContextOptions<NoteDb> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("notes");
            entity.Property(note => note.Id).HasColumnName("id");
            entity.Property(note => note.UserId).HasColumnName("user_id");
            entity.Property(note => note.Header).HasColumnName("header");
            entity.Property(note => note.Text).HasColumnName("text");
            entity.Property(note => note.Date).HasColumnName("date");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.Property(user => user.Id).HasColumnName("id");
            entity.Property(user => user.Name).HasColumnName("name");
            entity.Property(user => user.Password).HasColumnName("password");
        });
    }
    public DbSet<Note> Notes
    {
        get
        {
            return Set<Note>();
        }
    }

    public DbSet<User> Users
    {
        get
        {
            return Set<User>();
        }
    }
}
