export function Enumeration<T>() {
  return class Enumeration {
    static _instances: Record<string, T>;

    static get keys() {
      return Object.keys(this._instances);
    }

    static get values() {
      return Object.values(this._instances);
    }

    // #Instance
    _key!: string;

    get key() {
      return this._key;
    }

    _ordinal!: number;

    get ordinal() {
      return this._ordinal;
    }

    static closeEnum(callback?: () => void) {
      if (this._instances == null) {
        if (callback) {
          callback();
        }
        const instances: Record<string, T> = {};
        // Traverse the enum entries
        Object.entries(this)
          .forEach(([key, value],
                    index) => {
            const keyAsString = key as string;

            instances[keyAsString] = value as T;
            value._key = keyAsString;
            value._ordinal = index;
          });

        this._instances = instances;
      }
    }

    static fromName(name: string): undefined | T {
      if (!name || name.length === 0) {
        return undefined;
      }

      name = name.toLowerCase();

      const keys = Object.keys(this._instances);

      let value = undefined;

      keys.forEach(key => {
        if (key.toLowerCase() === name) {
          value = this._instances[key];
        }
      });

      return value;
    }

    static [Symbol.iterator]() {
      return this.values[Symbol.iterator]();
    }

    static fromString(str: string): undefined | T {
      return this.fromName(str);
    }

    equal(a: any) {
      return this?._key && a?._key && this?._key === a._key && typeof this === typeof a;
    }

    toString() {
      return this.key;
    }
  };
}