CREATE TABLE Kullanıcılar (
    u_id INT IDENTITY(1,1) PRIMARY KEY,
    u_username NVARCHAR(50) NOT NULL UNIQUE,
    u_password NVARCHAR(255) NOT NULL,
    u_admin_level INT NOT NULL DEFAULT 0
);
