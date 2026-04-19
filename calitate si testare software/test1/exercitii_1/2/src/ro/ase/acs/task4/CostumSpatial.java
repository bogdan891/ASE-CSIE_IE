package ro.ase.acs.task4;

public class CostumSpatial {
    // Atributele sunt private pentru a nu fi modificate direct
    private boolean jetpack;
    private boolean scutAntiRadiatii;
    private boolean oxigenSuplimentar;
    private boolean nightVision;
    private boolean cizmeMagnetice;

    // 1. Constructor privat - accesibil doar prin Builder
    private CostumSpatial() {}

    @Override
    public String toString() {
        return "Costum Spațial: [Jetpack=" + jetpack +
                ", Scut=" + scutAntiRadiatii +
                ", Oxigen=" + oxigenSuplimentar +
                ", NightVision=" + nightVision +
                ", Cizme=" + cizmeMagnetice + "]";
    }

    public static class Builder {
        private CostumSpatial costum;

        public Builder() {
            this.costum = new CostumSpatial();
        }

        public Builder addJetpack(boolean value) {
            this.costum.jetpack = value;
            return this;
        }

        public Builder addScut(boolean value) {
            this.costum.scutAntiRadiatii = value;
            return this;
        }

        public Builder addOxigen(boolean value) {
            this.costum.oxigenSuplimentar = value;
            return this;
        }

        public Builder addNightVision(boolean value) {
            this.costum.nightVision = value;
            return this;
        }

        public Builder addCizme(boolean value) {
            this.costum.cizmeMagnetice = value;
            return this;
        }

        public CostumSpatial build() {
            return this.costum;
        }
    }
}
