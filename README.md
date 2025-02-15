# **Sistema CRM para Gestión de Solicitudes de Voluntariado en Refugios de Animales**

Este proyecto es un sistema CRM diseñado para gestionar solicitudes de voluntariado en refugios de animales. Permite la gestión de voluntarios, tareas, animales, recursos y adopciones de manera eficiente.

---

## **Requisitos del Sistema**

### **Requisitos de Software**
- **SQL Server**: Versión 2019 o superior.
- **.NET Core**: Versión 8.0.
- **Entity Framework Core**: Para la gestión de la base de datos.
- **Swagger**: Para documentación y pruebas de la API.

### **Requisitos de Hardware**
- **Procesador**: Intel i5 o equivalente (recomendado Intel i7 o superior).
- **Memoria RAM**: 8 GB (recomendado 16 GB).
- **Almacenamiento**: 10 GB de espacio libre (para la base de datos y el proyecto).
- **Sistema Operativo**: Windows 10/11, macOS, o Linux (Ubuntu recomendado).

---

## **Instalación y Configuración**

### **1. Clonar el Repositorio**
Clona el repositorio en tu máquina local:
```bash
git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio
```

### **2. Configurar la Base de Datos**
Crea una base de datos en SQL Server y configura la cadena de conexión en el archivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CRMRefugioAnimales;Trusted_Connection=True;"
  }
}
```

### **3. Restaurar la Base de Datos desde un Backup (.bak):**
Restaura la base de datos desde un archivo `.bak` en SQL Server Management Studio:
1. Haz clic derecho en la base de datos y selecciona `Tasks > Restore > Database...`.
2. Selecciona `Device` y busca el archivo `.bak` en tu máquina local.
3. Haz clic en `OK` para restaurar la base de datos.

### **4. Compilar y Ejecutar el Proyecto**
Abre el proyecto en Visual Studio y compila la solución. Luego, ejecuta el proyecto en modo Debug.

### **5. Acceder a la Aplicación**
Abre tu navegador web y accede a la URL `https://localhost:5001` para ver la aplicación en funcionamiento.

---

## **Funcionalidades Principales**

### **1. Gestión de Voluntarios**
Permite registrar, editar y eliminar voluntarios, así como asignarles tareas y ver su historial de actividades.

### **2. Gestión de Tareas**
Permite crear, asignar y completar tareas para los voluntarios, con fechas límite y descripciones detalladas.

### **3. Gestión de Animales**
Permite registrar y editar animales en el refugio, incluyendo información sobre su raza, edad, género y estado de salud.

### **4. Gestión de Recursos**

Permite gestionar los recursos disponibles en el refugio, como alimentos, medicamentos, jaulas y otros suministros.

### **5. Gestión de Adopciones**

Permite registrar y gestionar las adopciones de animales, incluyendo información sobre los adoptantes y los

---