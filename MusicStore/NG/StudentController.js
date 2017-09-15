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
        $scope.student = '';
    }
    // Adding New student record  
    $scope.AddStudnet = function (student) {
        StudentService.AddNewStudent(student).success(function (msg) {
            alert('save successfully.');
            $scope.students.push(msg)
            $scope.dvStudent = false;
        }, function () {
            alert('Error in adding record');
        });
    }
    // Deleting record.  
    $scope.deleteStudent = function (stu, index) {
        var con = confirm('sure to delete? Student ID=' + index);
        if (!con) { return false; }
        var retval = StudentService.deleteStudent(stu.ID).success(function (msg) {
            $scope.students.splice(index, 1);
            //alert('Student has been deleted successfully.');
            GetStudentList();
        }).error(function () {
            alert('Oops! something went wrong.');
        });
    }
    // Updateing Records  
    $scope.UpdateStudent = function (tbl_Student) {
        var RetValData = StudentService.UpdateStudent(tbl_Student);
        RetValData.success(function () {
            //alert('Update success')
        }).error(function () {
            alert('Error in getting records');
        });
        //getData.then(function (tbl_Student) {
        //    Id: $scope.Id;
        //    StudentName: $scope.studentName;
        //    StudentAddress: $scope.StudentAddress;
        //    StudentEmail: $scope.StudentEmail;
        //}, function () {
        //    alert('Error in getting records');
        //});
    }
});