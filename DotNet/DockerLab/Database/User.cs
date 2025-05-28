namespace DockerLab.Database;

public class User
{
    public User(string name, int age)
    {
        if (string.IsNullOrEmpty(name) || age < 0)
            throw new ArgumentException("Incorrect arguments");
        
        Name = name;
        Age = age;
    }
    public long Id { get; }
    public string Name { get; }
    public int Age { get; }
}