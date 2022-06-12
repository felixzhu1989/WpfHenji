using System.Collections.Generic;
using System.Linq;
using WpfMvvmDataGrid.Models;
namespace WpfMvvmDataGrid.Db;
/// <summary>
/// 模拟后台数据库，初始化数据，实现增删改查方法
/// </summary>
public class LocalDb
{
    private List<Student> StudentList;
    public LocalDb()
    {
        InitData();
    }
    /// <summary>
    /// 初始化30条数据
    /// </summary>
    private void InitData()
    {
        StudentList=new List<Student>();
        for (int i = 0; i < 30; i++)
        {
            StudentList.Add(new Student()
            {
                Id = i,
                Name =$"Name{i}"
            });
        }
    }
    /// <summary>
    /// 查询全部学员
    /// </summary>
    /// <returns></returns>
    public List<Student> GetStudents()
    {
        return StudentList;
    }
    /// <summary>
    /// 新增学员
    /// </summary>
    /// <param name="stu"></param>
    public void AddStudent(Student stu)
    {
        StudentList.Add(stu);
    }
    /// <summary>
    /// 删除学员
    /// </summary>
    /// <param name="id"></param>
    public void DeleteStudent(int? id)
    {
        var model=StudentList.FirstOrDefault(x => x.Id.Equals(id));
        if (model != null)
        {
            StudentList.Remove(model);
        }
    }
    /// <summary>
    /// 修改学员
    /// </summary>
    /// <param name="id"></param>
    public void EditStudent(Student stu)
    {
        var model = StudentList.FirstOrDefault(x => x.Id.Equals(stu.Id));
        if (model != null)
        {
            model.Name= stu.Name;
        }
    }
    /// <summary>
    /// 根据名称查找学员，模糊查找
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<Student> GetStudentsByName(string name)
    {
        return StudentList.Where(x => x.Name.Contains(name)).ToList();
    }
    public Student GetStudentById(int? id)
    {
        var model=StudentList.FirstOrDefault(x=>x.Id.Equals(id));
        if (model!=null)
        {
            return new Student()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        return null;
    }
}
