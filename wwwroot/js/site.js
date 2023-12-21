const id = (id) => document.getElementById(id);

const clermsg = (event) => {
    event.target.nextElementSibling.classList.add("hidden");
}

const hideerrors = () => {
    document.querySelectorAll('small').forEach((each) => {
        each.classList.add("hidden");
    });
}

const validatestring = HTMLInputElement => {
    let element = HTMLInputElement.value;
    if (element.length > 0 && element != null) {
        return true;
    } else {
        HTMLInputElement.nextElementSibling.classList.remove("hidden");
        return false;
    };
}

const validatemail = HTMLInputElement => {
    let mail = HTMLInputElement.value;
    if (mail.length > 0 && mail != null && mail.includes("@")) {
        return true;

    }
    else {
        HTMLInputElement.nextElementSibling.classList.remove("hidden");
        console.log("unvalidated");
        return false;
    }
}

const validatedob = HTMLInputElement => {
    let element = HTMLInputElement.value;
    if (new Date(element) < Date.parse("2006-12-25") && element != null) {
        return true;
    } else {
        HTMLInputElement.nextElementSibling.classList.remove("hidden");
        return false;
    };
}

const validateadmdate = HTMLInputElement => {
    let element = HTMLInputElement.value;
    if (new Date(element) <= new Date() && new Date(element) != null) {
        return true;
    } else {
        HTMLInputElement.nextElementSibling.classList.remove("hidden");
        return false;
    };
}

const validatePhone = HTMLInputElement => {
    let element = HTMLInputElement.value;
    if (element != null) {
        if (element.startsWith("0") && element.length == 11) {
            return true;
        } else if (element.startsWith("+") && element.length == 14) {
            return true;
        }
        else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        }
    } else {
        HTMLInputElement.nextElementSibling.classList.remove("hidden");
        return false;
    };
}


const validate = () => {
    hideerrors();
    validatestring(id("fname"));
    validatestring(id("lname"));
    validatestring(id("mname"));
    validatePhone(id("phone"));
    validatestring(id("Home_address"));
    validatestring(id("Department"));
    validatestring(id("Faculty"));
    validatestring(id("Level"));
    validatestring(id("Gender"));
    validatestring(id("Admission_number"));
    validatemail(id("Email"));
    validatestring(id("Course_of_study"));
    validateadmdate(id("Admission_date"));
    validatedob(id("Date_of_birth"));

    if (validatestring(id("fname")) && validatestring(id("Faculty")) && validatestring(id("mname")) && validatestring(id("Admission_number")) && validateadmdate(id("Admission_date")) && validatedob(id("Date_of_birth")) && validatestring(id("lname")) && validatePhone(id("phone")) && validatestring(id("Admission_number")) && validatestring(id("Home_address")) && validatestring(id("Gender")) && validatemail(id("Email")) && validatestring(id("Course_of_study"))) {
        console.log("validated");
        return true;
    } else {
        return false;
    }
}



const validatecourse = () => {
    hideerrors();
    validatestring(id("Title"));
    validatestring(id("Code"));
    validatestring(id("Unit"));

    if (validatestring(id("Title")) && validatestring(id("Code")) && validatestring(id("Unit"))) {
        return true;
    } else {
        return false;
    }
}

const validatescore = () => {
    hideerrors();
    const validatestring = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element != null && element.length > 0) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    const validateCA = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element != null && element.length > 0 && element <= 10 && element > 0) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    const validateExam = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element != null && element.length > 0 && element <= 70  && element > 0) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    validatestring(id("Matric_number"));
    validateCA(id("CA_1"));
    validateCA(id("CA_2"));
    validateCA(id("CA_3"));
    validateExam(id("Exam_score"));
    validatestring(id("Year"));
    validatestring(id("Semester"));
    validatestring(id("Level"));

    if (validatestring(id("Matric_number")) && validateCA(id("CA_1")) && validateCA(id("CA_2")) && validatestring(id("Year")) && validatestring(id("CA_3")) && validateExam(id("Exam_score")) && validatestring(id("Semester")) && validatestring(id("Level"))) {
        console.log("Validated");
        return true;
    } else {
        console.log("Not validated")
        return false;
    }
}

