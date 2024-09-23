
CREATE TABLE Rotalar (
    rota_id INT IDENTITY(1,1) PRIMARY KEY,
    siparis_id INT NOT NULL,
    rota_adi NVARCHAR(100) NOT NULL,
    ucret DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (siparis_id) REFERENCES Siparisler(id) ON DELETE CASCADE
);
