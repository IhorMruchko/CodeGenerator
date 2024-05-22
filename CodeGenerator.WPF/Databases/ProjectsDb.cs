using CodeGenerator.LIB.Utils.Connections;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Resources.Constants;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.WPF.Databases;

public class ProjectsDb
{
    private readonly JsonIOService<List<Project>> _connection;

    private readonly List<Project> _source = new();

    public ProjectsDb()
    {
        _connection = new(Constants.APPLICATION_DIRECTORY, Constants.PROJECTS_FILENAME);
    }

    public Project GetOrCreate(Project target)
    {
        var selectedProject = _source.FirstOrDefault(project => project.Directory == target.Directory && project.Title == target.Title);

        if (selectedProject is not null)
        {
            return selectedProject;
        }

        _source.Add(target);
        return target;
    }
}
