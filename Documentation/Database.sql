DROP DATABASE PetSystem;
CREATE DATABASE PetSystem;

USE PetSystem;

CREATE TABLE province 
(
    province_id INT NOT NULL PRIMARY KEY IDENTITY,
    province_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE city
(
    city_id INT NOT NULL PRIMARY KEY IDENTITY,
    city_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    province_id INT NOT NULL,
    CONSTRAINT FK_CITY_PROVINCE_ID FOREIGN KEY(province_id) REFERENCES province(province_id)
);

CREATE TABLE tasks 
(
    task_id INT NOT NULL PRIMARY KEY IDENTITY,
    task_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE users 
(
    user_id INT NOT NULL PRIMARY KEY IDENTITY,
    first_name VARCHAR(155) NOT NULL,
    last_name VARCHAR(155) NOT NULL,
    email VARCHAR(255) NOT NULL,
	password VARCHAR(155) NOT NULL,
    direction VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    province_id INT NOT NULL,
    CONSTRAINT FK_USER_PROVINCE_ID FOREIGN KEY(province_id) REFERENCES province(province_id)
);

CREATE TABLE roles 
(
    role_id INT NOT NULL PRIMARY KEY IDENTITY,
    role_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE user_role 
(
    user_role_id INT NOT NULL PRIMARY KEY IDENTITY,
    role_id INT NOT NULL,
    user_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_USER_ROLE_ROLE_ID FOREIGN KEY(role_id) REFERENCES roles(role_id),
    CONSTRAINT FK_USER_ROLE_USER_ID FOREIGN KEY(user_id) REFERENCES users(user_id)
);

CREATE TABLE offices 
(
    office_id INT NOT NULL PRIMARY KEY IDENTITY,
    office_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    direction VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    city_id INT NOT NULL,
    CONSTRAINT FK_OFFICE_CITY_ID FOREIGN KEY(city_id) REFERENCES city(city_id)
);

CREATE TABLE statuses
(
    status_id INT NOT NULL PRIMARY KEY IDENTITY,
    status_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE care_task 
(
    care_task_id INT NOT NULL PRIMARY KEY IDENTITY,
    name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE priority
(
    priority_id INT NOT NULL PRIMARY KEY IDENTITY,
    priority_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE user_care_task 
(
    user_care_task_id INT NOT NULL PRIMARY KEY IDENTITY,
    user_id INT NOT NULL,
    office_id INT NOT NULL,
    priority_id INT NOT NULL,
    status_id INT NOT NULL,
    care_task_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    exp_date DATETIME NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_USER_CARE_TASK_USER_ID FOREIGN KEY(user_id) REFERENCES users(user_id),
    CONSTRAINT FK_USER_CARE_TASK_OFFICE_ID FOREIGN KEY(office_id) REFERENCES offices(office_id),
    CONSTRAINT FK_USER_CARE_TASK_PRIORITY_ID FOREIGN KEY(priority_id) REFERENCES priority(priority_id),
    CONSTRAINT FK_USER_CARE_TASK_CARE_TASK_ID FOREIGN KEY(care_task_id) REFERENCES care_task(care_task_id),
    CONSTRAINT FK_USER_CARE_TASK_STATUS_ID FOREIGN KEY(status_id) REFERENCES statuses(status_id)
);

CREATE TABLE pet_type 
(
    pet_type_id INT NOT NULL PRIMARY KEY IDENTITY,
    pet_type_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE pets
(
    pet_id INT NOT NULL PRIMARY KEY IDENTITY,
    first_name VARCHAR(155) NOT NULL,
    last_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    pet_type_id INT NOT NULL,
    CONSTRAINT FK_PET_PET_TYPE_ID FOREIGN KEY(pet_type_id) REFERENCES pet_type(pet_type_id)
);

CREATE TABLE clients
(
    client_id INT NOT NULL PRIMARY KEY IDENTITY,
    client_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(255) NOT NULL,
    direction VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    city_id INT NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_CLIENT_CITY_ID FOREIGN KEY(city_id) REFERENCES city(city_id)
);

CREATE TABLE pet_client_adoption
(
    adoption_id INT NOT NULL PRIMARY KEY IDENTITY,
    client_id INT NOT NULL,
    pet_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_ADOPTION_CLIENT_ID FOREIGN KEY(client_id) REFERENCES clients(client_id),
	CONSTRAINT FK_ADOPTION_PET_ID FOREIGN KEY(pet_id) REFERENCES pets(pet_id)
);

CREATE TABLE user_tasks 
(
    user_task_id INT NOT NULL PRIMARY KEY IDENTITY,
    user_id INT NOT NULL,
    status_id INT NOT NULL,
    office_id INT NOT NULL,
    priority_id INT NOT NULL,
    task_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_USER_TASK_USER_ID FOREIGN KEY(user_id) REFERENCES users(user_id),
    CONSTRAINT FK_USER_TASK_STATUS_ID FOREIGN KEY(status_id) REFERENCES statuses(status_id),
    CONSTRAINT FK_USER_TASK_OFFICE_ID FOREIGN KEY(office_id) REFERENCES offices(office_id),
    CONSTRAINT FK_USER_TASK_PRIORITY_ID FOREIGN KEY(priority_id) REFERENCES priority(priority_id),
    CONSTRAINT FK_USER_TASK_TASK_ID FOREIGN KEY(task_id) REFERENCES tasks(task_id)
);

CREATE TABLE resources 
(
    resource_id INT NOT NULL PRIMARY KEY IDENTITY,
    resource_name VARCHAR(155) NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1)
);

CREATE TABLE resource_care_task
(
    resource_care_task_id INT NOT NULL PRIMARY KEY IDENTITY,
    resource_id INT NOT NULL,
    care_task_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_RESOURCE_CARE_TASK_RESOURCE_ID FOREIGN KEY(resource_id) REFERENCES resources(resource_id),
    CONSTRAINT FK_RESOURCE_CARE_TASK_CARE_TASK_ID FOREIGN KEY(care_task_id) REFERENCES care_task(care_task_id)
);

CREATE TABLE resource_task 
(
    resource_task_id INT NOT NULL PRIMARY KEY IDENTITY,
    resource_id INT NOT NULL,
    task_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_RESOURCE_TASK_RESOURCE_ID FOREIGN KEY(resource_id) REFERENCES resources(resource_id),
    CONSTRAINT FK_RESOURCE_TASK_TASK_ID FOREIGN KEY(task_id) REFERENCES tasks(task_id)
);

CREATE TABLE resource_stock
(
    resource_stock_id INT NOT NULL PRIMARY KEY IDENTITY,
    resource_id INT NOT NULL,
    office_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_RESOURCE_STOCK_RESOURCE_ID FOREIGN KEY(resource_id) REFERENCES resources(resource_id),
    CONSTRAINT FK_RESOURCE_STOCK_OFFICE_ID FOREIGN KEY(office_id) REFERENCES offices(office_id)
);

CREATE TABLE medical_history
(
    medical_history_id INT NOT NULL PRIMARY KEY IDENTITY,
    pet_id INT NOT NULL,
    resource_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_MEDICAL_HISTORY_PET_ID FOREIGN KEY(pet_id) REFERENCES pets(pet_id),
    CONSTRAINT FK_MEDICAL_HISTORY_RESOURCE_ID FOREIGN KEY(resource_id) REFERENCES resources(resource_id)
);


CREATE TABLE pet_care 
(
    pet_care_task_id INT NOT NULL PRIMARY KEY IDENTITY,
    pet_id INT NOT NULL,
    care_task_id INT NOT NULL,
    description VARCHAR(255) NOT NULL,
    created_at DATETIME NOT NULL,
    modified_at DATETIME NOT NULL,
    is_active BIT NOT NULL DEFAULT(1),
    CONSTRAINT FK_PET_CARE_PET_ID FOREIGN KEY(pet_id) REFERENCES pets(pet_id),
    CONSTRAINT FK_PET_CARE_TASK_ID FOREIGN KEY(care_task_id) REFERENCES care_task(care_task_id)
);
