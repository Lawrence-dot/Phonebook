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
    validatePhone(id("phone"));
    validatestring(id("Home_address"));
    validatestring(id("Department"));
    validatestring(id("Faculty"));
    validatestring(id("Level"));
    validatestring(id("Gender"));
    validatestring(id("Email"));
    validatestring(id("Course_of_study"));

    if (validatestring(id("fname")) && validatestring(id("lname")) && validatePhone(id("phone")) && validatestring(id("Admission_number")) && validatestring(id("Home_address")) && validatestring(id("Department")) && validatestring(id("Faculty")) && validatestring(id("Level")) && validatestring(id("Gender")) && validatestring(id("Email")) && validatestring(id("Course_of_study"))) {
        return true;
    } else {
        return false;
    }
}

const clermsg = (event) => {
    event.target.nextElementSibling.classList.add("hidden");
}