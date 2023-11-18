const validate = () => {
    document.querySelectorAll('small').forEach((each) => {
        each.classList.add("hidden");
    });
    let id = (id) => document.getElementById(id);
    const validatestring = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.length > 1 && element != null) {
            return true;
        } else {
            HTMLInputElement.nextElementSibling.classList.remove("hidden");
            return false;
        };
    }

    const validatePhone = HTMLInputElement => {
        let element = HTMLInputElement.value;
        if (element.length == 11 && element != null) {
            if (element.startsWith("090") || element.startsWith("080") || element.startsWith("070")) {
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
    validatePhone(id("pphone"));
    validatestring(id("sphone"));

    if (validatestring(id("fname")) && validatestring(id("lname")) && validatePhone(id("pphone")) && validatestring(id("sphone"))) {
        return true;
    } else {
        return false;
    }
}

const clermsg = (event) => {
    event.target.nextElementSibling.classList.add("hidden");
}