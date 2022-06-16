
const setActive = (e) => {

  e.setAttribute("class", "active");
  console.log(e, this)
};

const navItems = document.querySelectorAll(".topnav a#nav-link");
navItems.forEach( e => e.onclick( setActive(e) ));
