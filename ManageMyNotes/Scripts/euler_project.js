var EulerProject = new function () {
    this.Problem1 = function (x) {
        var i = 1;
        var result = 0;
        while (i < x) {
            if (i % 3 === 0 || i % 5 === 0) {
                result += i;
            }
            i++;
        }
        return result;
    };
    this.Problem2 = function (x) {
        var fib1 = 1;
        var fib2 = 1;
        var temp = 0;
        var result = 0;
        while (result < x) {
            temp = fib1 + fib2;
            fib1 = fib2;
            fib2 = temp;
            if (temp % 2 === 0) {
                result += temp;
            }
        }
        return result + EulerProject.NewEntity;
    };
    this.Problem3 = function (x) {
        var prime = 0;
        for (var i = 2; i < x; i++) {
            if (x % i === 0)
                var isPrime = true;
            for (var j = 2; j < i; j++) {
                if (i % j === 0) {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) {
                prime = i;
            }
        }
        return prime;
    };
}
EulerProject.NewEntity = "I am new content";