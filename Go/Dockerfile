FROM golang:1.24 AS builder

WORKDIR /app

COPY go.mod .
COPY go.sum .
RUN go mod download

COPY . .

RUN go build -o fizzbuzz

FROM gcr.io/distroless/base

COPY --from=builder /app/fizzbuzz /fizzbuzz
COPY --from=builder /app/templates /templates

EXPOSE 8080

ENTRYPOINT ["/fizzbuzz", "serve"]