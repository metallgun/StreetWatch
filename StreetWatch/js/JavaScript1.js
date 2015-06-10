function sv_order() {
    var obj = this;
    this.name = "";
    this.mail = "";
    this.coords = {
        lattitude: 0,
        longitude: 0
    };
    this.comment = "";
    this.address = "";
    this.urgent = false;
    this.planDate = new Date();
};