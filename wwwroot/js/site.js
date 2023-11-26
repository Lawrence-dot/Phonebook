const validate = () => {
    document.querySelectorAll('small').forEach((each) => {
        each.classList.add("hidden");
    });

    let id = (id) => document.getElementById(id);

    const validatestring = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.length > 0 && element != null) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    const validatedob = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.value > Date.parse("2006-12-25") && element.value <= new Date() && element.value != null && element.v) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    const validatemail = HTMLInputElement =>

    {
        let mail = HTMLInputElement.value;
            if (mail.Length > 0 && mail != null && mail.Contains(".com")) {
                return true;
            }
            else {
                HTMLInputElement.nextElementSibling.classList.remove("hidden");
                return false;
            }
        }

    const validateadmdate = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.value <= new Date() && element.value != null) {
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

    if (validatestring(id("fname")) && validatestring(id("mname")) && validatestring(id("Admission_number")) && validateadmdate("Admission_date") && validatedob("Date_of_birth") && validatestring(id("lname")) && validatePhone(id("phone")) && validatestring(id("Admission_number")) && validatestring(id("Home_address")) && validatestring(id("Gender")) && validatemail(id("Email")) && validatestring(id("Course_of_study"))) {
        console.log("validated");
        return true;
    } else {
        return false;
    }
}

const clermsg = (event) => {
    event.target.nextElementSibling.classList.add("hidden");
}

const validatecourse = () => {
    document.querySelectorAll('small').forEach((each) => {
        each.classList.add("hidden");
    });

    let id = (id) => document.getElementById(id);

    const validatestring = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.length > 0 && element != null) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    const validatelevel = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.length > 0 && element != null && Number(elemnt) >= 100 ) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    validatestring(id("Title"));
    validatestring(id("Code"));
    validatestring(id("Unit"));

    if (validatestring(id("Title")) && validatestring(id("Code")) && validatestring(id("Unit"))) {
        return true;
    } else {
        return false;
    }
}

