app.controller("stuCntr", function ($scope, StudentService) {
    $scope.dvStudent = false;
    //GetStudentList();
    $scope.students = GetStudentList();
    //To Get All Records  
    function GetStudentList() {
        StudentService.getAllStudents()
        .success(function (stu) {
            $scope.students = stu;
        }).error(function () {
            alert('Error in getting records');
        });
    }
    // To display Add div  
    $scope.AddNewStudent = function () {
        $scope.Action = "Add";
        $scope.dvStudent = true;
    }
    // Adding New student record  
    $scope.AddStudnet = function (student) {
        StudentService.AddNewStudent(student).success(function (msg) {
            $scope.students.push(msg)
            $scope.dvAddStudnet = false;
        }, function () {
            alert('Error in adding record');
        });
    }
    // Deleting record.  
    $scope.deleteStudent = function (stu, index) {
        var retval = StudentService.deleteStudent(stu.Id).success(function (msg) {
            $scope.students.splice(index, 1);
            // alert('Student has been deleted successfully.');  
        }).error(function () {
            alert('Oops! something went wrong.');
        });
    }
    // Updateing Records  
    $scope.UpdateStudent = function (tbl_Student) {
        var RetValData = StudentService.UpdateStudent(tbl_Student);
        getData.then(function (tbl_Student) {
            Id: $scope.Id;
            StudentName: $scope.studentName;
            StudentAddress: $scope.StudentAddress;
            StudentEmail: $scope.StudentEmail;
        }, function () {
            alert('Error in getting records');
        });
    }
});