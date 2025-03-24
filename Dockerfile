# Usa Python 3.9 come base
FROM python:3.14-rc-alpine3.21

# Imposta la directory di lavoro
WORKDIR /app

# Copia i file del progetto dentro il container
COPY . /app

# Installa le dipendenze
RUN pip install --no-cache-dir -r requirements.txt

# Esponi la porta 5000
EXPOSE 5000

# Esegui l'applicazione Flask
CMD ["python", "app.py"]
