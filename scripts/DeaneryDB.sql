CREATE DATABASE DeaneryDB
COLLATE CyrilLic_General_CI_AS
GO

CREATE TABLE Students
(
	student_id INT NOT NULL IDENTITY PRIMARY KEY,
	name nvarchar(20) NOT NULL,
	surname nvarchar(20) NOT NULL,
	patronymic nvarchar(20) NOT NULL,
	studying_form int DEFAULT 0,
	speciality nvarchar(50) NOT NULL,
	group_name nvarchar(10) NOT NULL,
	year int NOT NULL,
	semester int NOT NULL,
	average_mark FLOAT NOT NULL
)
GO

INSERT INTO Students(name, surname, patronymic, studying_form, speciality, group_name, year, semester, average_mark)
VALUES ('Иванов', 'Иван', 'Иванович', 0, 'Искусственный интеллект', 'ИИ-121', 2, 3, 7.2)
GO

CREATE TABLE Users
(
	user_id INT NOT NULL IDENTITY PRIMARY KEY,
	login nvarchar(10) NOT NULL,
	password nvarchar(10) NOT NULL,
	fio nvarchar(100) NOT NULL,
	role int DEFAULT 2
)
GO

INSERT INTO Users(login, password, fio, role)
VALUES ('admin', '123', 'Иванов Иван Иванович', 0)
GO

CREATE TABLE Subjects
(
	subject_id INT NOT NULL IDENTITY PRIMARY KEY,
	short_name nvarchar(10) NOT NULL,
	long_name nvarchar(50) NOT NULL
)

INSERT INTO Subjects(short_name, long_name)
VALUES ('ППвИС', 'Проектирование программ в интеллектульных системах'),
	   ('ЛОИС', 'Логические основы интеллектульных систем')
GO

CREATE TABLE Progress
(
	progress_id INT NOT NULL IDENTITY PRIMARY KEY,
	student_id INT NOT NULL,
	FOREIGN KEY(student_id) REFERENCES Students(student_id)
)
GO

CREATE TABLE Semesters
(
	semester_id INT NOT NULL IDENTITY PRIMARY KEY,
	progress_id INT NOT NULL,
	FOREIGN KEY(progress_id) REFERENCES Progress(progress_id)
)
GO

CREATE TABLE Exams
(
	exam_id INT NOT NULL IDENTITY PRIMARY KEY,
	subject_id INT NOT NULL,
	mark INT NOT NULL,
	semester_id INT NOT NULL,
	FOREIGN KEY(semester_id) REFERENCES Semesters(semester_id)
)
GO

CREATE TABLE Attendance
(
	attendance_id INT NOT NULL IDENTITY PRIMARY KEY,
	subject_id INT NOT NULL,
	student_id INT NOT NULL,
	fio nvarchar(100) NOT NULL,
	year int NOT NULL,
	semester int NOT NULL,
	FOREIGN KEY(subject_id) REFERENCES Subjects(subject_id),
	FOREIGN KEY(student_id) REFERENCES Students(student_id)
)
GO

CREATE TABLE Lessons
(
	lesson_id INT NOT NULL IDENTITY PRIMARY KEY,
	attendance_id INT NOT NULL,
	lesson_date DATETIME NOT NULL,
	FOREIGN KEY(attendance_id) REFERENCES Attendance(attendance_id)
)
GO

CREATE TABLE LessonStudents
(
	ls_id INT NOT NULL IDENTITY PRIMARY KEY,
	student_id INT NOT NULL,
	is_visited BIT NOT NULL DEFAULT 0,
	FOREIGN KEY(student_id) REFERENCES Students(student_id)
)
GO